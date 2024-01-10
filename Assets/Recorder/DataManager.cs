using System;
using System.IO;
using Assets.Recorder;
using Assets.Recorder.DataModels;
using Assets.Recorder.DataModels.OpenXR;
using CsvHelper;
using Newtonsoft.Json;
using Recorder.Entities.OculusVR;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Recorder
{
    internal class DataManager
    {
        public double floorHeight = 0;


        // property normalizacji danych
        public Vector2 headPosition2D;
        public double[,] macierzRotacji = new double[2, 2];
        public float rotacjaHeadsetaWosiY;
        private double _rotacjaHeadsetaWosiY;
        private double _wysokoscGracza;


        // private props

        internal OpenXRInputActionsStruct OpenXRInputActions { get; set; }

        internal InputActionMap LeftController { get; set; }
        internal InputActionMap RightController { get; set; }
        internal InputActionMap HeadController { get; set; }
        internal TimeSpan StartRecordingTime { get; set; }

        

        internal void AddRecord(ref StreamWriter stream, ref CsvWriter csvstream)
        {
            Record record = new();
            LeftControllerVREntity left = new();
            RightControllerVREntity right = new();
            HeadVREntity head = new();
            float floatTolerance = 0.00001f;
            var Hpos = HeadController["Position"];
            var headPosition = Hpos.ReadValue<Vector3>();
            headPosition2D = new Vector2(headPosition.x, headPosition.z);

            if (OpenXRInputActions.leftMenuPressed != null)
                left.L_ButtonMenuPressed = Math.Abs(OpenXRInputActions.leftMenuPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftPrimaryButtonPressed != null)
                left.L_ButtonXPressed = Math.Abs(OpenXRInputActions.leftPrimaryButtonPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftPrimaryButtonTouched != null)
                left.L_ButtonXTouched = Math.Abs(OpenXRInputActions.leftPrimaryButtonTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftSecondaryButtonPressed != null)
                left.L_ButtonYPressed = Math.Abs(OpenXRInputActions.leftSecondaryButtonPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftSecondaryButtonTouched != null)
                left.L_ButtonYTouched = Math.Abs(OpenXRInputActions.leftSecondaryButtonTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftTriggerPressed != null)
                left.L_TrigPressed = Math.Abs(OpenXRInputActions.leftTriggerPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftTriggerPressedValue != null)
                left.L_TrigValue = OpenXRInputActions.leftTriggerPressedValue.action.ReadValue<float>();


            if (OpenXRInputActions.leftTriggerTouched != null)
                left.L_TrigTouched = Math.Abs(OpenXRInputActions.leftTriggerTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftThumbStickPressed != null)
                left.L_JoyPressed = Math.Abs(OpenXRInputActions.leftThumbStickPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftThumbStickTouched != null)
                left.L_JoyTouched = Math.Abs(OpenXRInputActions.leftThumbStickTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.leftThumbStickMove != null)
                left.L_JoyX = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.x;


            if (OpenXRInputActions.leftThumbStickMove != null)
                left.L_JoyY = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.y;


            if (OpenXRInputActions.leftGripPressed != null)
                left.L_GripPressed = Math.Abs(OpenXRInputActions.leftGripPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (LeftController != null)
            {
                var Lpos = LeftController["Position"];
                _wysokoscGracza = headPosition.y - floorHeight;
                // ReSharper disable once InconsistentNaming
                Vector2 headPosition2DV2 = new(headPosition.x, headPosition.z);
                //Position normalization
                var leftConPosV3 = Lpos.ReadValue<Vector3>();
                var leftPosOnUnity = new Vector3(leftConPosV3.x, leftConPosV3.z, leftConPosV3.y);
                double leftConX = leftPosOnUnity.x - headPosition2DV2.x;
                double leftConZ = leftPosOnUnity.y - headPosition2DV2.y;
                double y = leftPosOnUnity.z;

                //Rotation normalization
                var xPoObrocie = leftConX * macierzRotacji[0,0] - leftConZ * macierzRotacji[0,1];
                var zPoObrocie = leftConX * macierzRotacji[1,0] + leftConZ * macierzRotacji[1,1];

                //Finally normalization
                var xPoNormalizacji = xPoObrocie / (_wysokoscGracza / 2);
                var zPoNormalizacji = zPoObrocie / (_wysokoscGracza / 2);
                var yPoNormalizacji = y / (_wysokoscGracza / 2);
                // Debug.Log(
                //     $"Pozycja lewego kontrolera znormalizowana: X: {xPoNormalizacji}\n Z: {zPoNormalizacji}\n Y: {yPoNormalizacji}, a nie znormalizowana: X: {leftPosOnUnity.x}\n Z: {leftPosOnUnity.z}\n Y: {leftPosOnUnity.y}");

                left.L_PosX = xPoNormalizacji;
                left.L_PosY = yPoNormalizacji;
                left.L_PosZ = zPoNormalizacji;
                
                //Rotation

                var lRot = LeftController["Rotation"];
                var rotation = lRot.ReadValue<Quaternion>();
                left.L_RotX = rotation.normalized.x;
                left.L_RotY = rotation.normalized.y;
                left.L_RotZ = rotation.normalized.z;
            }


            if (OpenXRInputActions.rightSystemPressed != null)
                right.R_BtnSysPress = Math.Abs(OpenXRInputActions.rightSystemPressed.action.ReadValue<float>() - 1) < floatTolerance;

            if (OpenXRInputActions.rightPrimaryButtonPressed != null)
                right.R_BtnAPressed = Math.Abs(OpenXRInputActions.rightPrimaryButtonPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightPrimaryButtonTouched != null)
                right.R_BtnATouched = Math.Abs(OpenXRInputActions.rightPrimaryButtonTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightSecondaryButtonPressed != null)
                right.R_BtnBPressed = Math.Abs(OpenXRInputActions.rightSecondaryButtonPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightSecondaryButtonTouched != null)
                right.R_BtnBTouched = Math.Abs(OpenXRInputActions.rightSecondaryButtonTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightTriggerPressed != null)
                right.R_TrigPressed = Math.Abs(OpenXRInputActions.rightTriggerPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightTriggerPressedValue != null)
                right.R_TrigValue = OpenXRInputActions.rightTriggerPressedValue.action.ReadValue<float>();


            if (OpenXRInputActions.rightTriggerTouched != null)
                right.R_TrigTouched = Math.Abs(OpenXRInputActions.rightTriggerTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightThumbStickPressed != null)
                right.R_JoyPressed = Math.Abs(OpenXRInputActions.rightThumbStickPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightThumbStickTouched != null)
                right.R_JoyTouched = Math.Abs(OpenXRInputActions.rightThumbStickTouched.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightGripPressed != null)
                right.R_GripPressed = Math.Abs(OpenXRInputActions.rightGripPressed.action.ReadValue<float>() - 1) < floatTolerance;


            if (OpenXRInputActions.rightThumbStickMove != null)
                right.R_JoyX = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.x;

            if (OpenXRInputActions.rightThumbStickMove != null)
                right.R_JoyY = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.y;

            if (RightController != null)
            {
                //Position
                        
                        
                        _wysokoscGracza = Hpos.ReadValue<Vector3>().y - floorHeight;
                        // ReSharper disable once InconsistentNaming
                        Vector2 HeadPosition2DV2 = new(headPosition.x, headPosition.z);
                         //Position normalization
                         var rPos = RightController["Position"];
                         var rightPosition = rPos.ReadValue<Vector3>();
                         
                         Vector3 position = new Vector3(rightPosition.x, rightPosition.z, rightPosition.y);
                        double rightConX = position.x - HeadPosition2DV2.x;
                        double rightConZ = position.y - HeadPosition2DV2.y;
                        double y = position.z;

                        //Rotation normalization
                        var xPoObrocie = rightConX * macierzRotacji[0,0] - rightConZ * macierzRotacji[0,1];
                        var zPoObrocie = rightConX * macierzRotacji[1,0] + rightConZ * macierzRotacji[1,1];

                        //Finally normalization
                        var xPoNormalizacji = xPoObrocie / (_wysokoscGracza / 2);
                        var zPoNormalizacji = zPoObrocie / (_wysokoscGracza / 2);
                        var yPoNormalizacji = y / (_wysokoscGracza / 2);
                        // Debug.Log(
                        //     $"Pozycja prawego kontrolera znormalizowana: X: {xPoNormalizacji}\n Z: {zPoNormalizacji}\n Y: {yPoNormalizacji}, a nie znormalizowana: X: {position.x}\n Z: {position.z}\n Y: {position.y}");

                        right.R_PosX = xPoNormalizacji;
                        right.R_PosY = yPoNormalizacji;
                        right.R_PosZ = zPoNormalizacji;
                    

               
                //Rotation

                var rRot = RightController["Rotation"];
                var rightRotation = rRot.ReadValue<Quaternion>();
                
                right.R_RotX = rightRotation.normalized.x;

                right.R_RotY = rightRotation.normalized.y;

                right.R_RotZ = rightRotation.normalized.z;
            }

            if (HeadController != null)
            {
                
                head.H_PosX = headPosition.normalized.x;

                head.H_PosY = headPosition.normalized.y;

                head.H_PosZ = headPosition.normalized.z;

                var hRot = HeadController["Rotation"];
                var headRotation = hRot.ReadValue<Quaternion>(); 
                head.H_RotX = headRotation.normalized.x;

                head.H_RotY = headRotation.normalized.y;

                head.H_RotZ = headRotation.normalized.z;
            }

            record.LeftController = left;
            record.RightController = right;
            record.Head = head;


            record.TimeSpan = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond) - StartRecordingTime;

            Debug.Log("Wpisuję rekord do csv");
            //Write to csv
            WriteRecordToCsv(record, ref csvstream);

            //Write to Json

            //TODO: Dodać inny stream z rozszerzeniem json i opisać konfigurację json

            /*
             * Zamienić powyższe na
             *
                    Dictionary<ActionConfigEnum, Func<object>> map = new(){
                      ActionConfigEnum.RecordLeftMenuPressed, () => OpenXRInputActions.LeftMenuPressed is not null && OpenXRInputActions.LeftMenuPressed.action.ReadValue<float>() == 1;
                    }

                    ...

                    class Record{
                      public Dictionary<ActionConfigEnum, object> LeftController {get;}
                    }

                    ...

                    for(ActionConfigEnum action in config) left.LeftController.Add(map[action].Invoke());

             *
             *
             */
        }


        //JSON Format
        internal void WriteHeaderToJsonFile()
        {
            throw new NotImplementedException();

            //TODO: Dodać początek i koniec pliku JSON z tytułem data
        }

        internal void WriteObjectToJson(object obj, ref StreamWriter stream)
        {
            if (obj is string)
            {
                var recordStringy = (string)obj;
                stream.Write(recordStringy);
            }
            else
            {
                string recordStringy;
                try
                {
                    recordStringy = JsonConvert.SerializeObject(obj);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    return;
                }

                stream.Write(
                    recordStringy + ","
                );
            }
        }

        //CSV Format
        internal void WriteHeaderToCsvFile(ref CsvWriter stream)
        {
            stream.WriteField("Kolejność urządzeń : Head Controller,  Left Controller, Right Controller");
            stream.NextRecord();
            stream.WriteHeader<Record>();
            stream.NextRecord();
        }

        internal void WriteRecordToCsv(Record record, ref CsvWriter stream)
        {
            stream.WriteRecord(record);
            stream.NextRecord();
        }
    }
}