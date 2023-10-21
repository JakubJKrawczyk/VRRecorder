using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Assets.Recorder;
using Assets.Recorder.DataModels;
using Assets.Recorder.DataModels.OpenXR;
using CsvHelper;
using Newtonsoft.Json;
using Recorder.Entities;
using Recorder.Entities.OculusVR;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Recorder
{
    internal class DataManager
    {
        //public props
        internal RecorderConfigurationStruct Configuration { get; set; }
        internal OpenXRInputActionsStruct OpenXRInputActions { get; set; }

        internal GameObject LeftController { get; set; }
        internal GameObject RightController { get; set; }
        internal GameObject HeadController { get; set; }
        internal TimeSpan StartRecordingTime { get; set; }

        // property normalizacji danych
        public double[,] macierzRotacji = new double[2, 2];
        public double floorHeight = 0;
        double RotacjaHeadsetaWosiY = 0;
        double wysokoscGracza = 0;

        // private props
        internal DataManager()
        {





        }
        private void GetHeadsetRotation()
        {
            RotacjaHeadsetaWosiY = HeadController.transform.rotation.eulerAngles.y;

        }
        public void SetNormalizationProperties()
        {
            GetHeadsetRotation();
            macierzRotacji[0, 0] = Math.Cos(RotacjaHeadsetaWosiY);
            macierzRotacji[1, 0] = Math.Sin(RotacjaHeadsetaWosiY);
            macierzRotacji[0, 1] = -Math.Sin(RotacjaHeadsetaWosiY);
            macierzRotacji[1, 1] = Math.Cos(RotacjaHeadsetaWosiY);

            wysokoscGracza = HeadController.transform.position.y - floorHeight;
        }
        internal void AddRecord(ref StreamWriter stream, ref CsvWriter csvstream)
        {

            Record record = new();
            LeftControllerVREntity left = new();
            RightControllerVREntity right = new();
            HeadVREntity head = new();


            Vector2 HeadPositionin2D = new Vector2(HeadController.transform.position.x, HeadController.transform.position.z);

            if (OpenXRInputActions.leftMenuPressed != null)
            {
                left.L_ButtonMenuPressed = OpenXRInputActions.leftMenuPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftPrimaryButtonPressed != null)
            {
                left.L_ButtonXPressed = OpenXRInputActions.leftPrimaryButtonPressed.action.ReadValue<float>() == 1;
            }



            if (OpenXRInputActions.leftPrimaryButtonTouched != null)
            {
                left.L_ButtonXTouched = OpenXRInputActions.leftPrimaryButtonTouched.action.ReadValue<float>() == 1;
            }



            if (OpenXRInputActions.leftSecondaryButtonPressed != null)
            {
                left.L_ButtonYPressed = OpenXRInputActions.leftSecondaryButtonPressed.action.ReadValue<float>() == 1;
            }



            if (OpenXRInputActions.leftSecondaryButtonTouched != null)
            {
                left.L_ButtonYTouched = OpenXRInputActions.leftSecondaryButtonTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftTriggerPressed != null)
            {
                left.L_TrigPressed = OpenXRInputActions.leftTriggerPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftTriggerPressedValue != null)
            {
                left.L_TrigValue = OpenXRInputActions.leftTriggerPressedValue.action.ReadValue<float>();
            }


            if (OpenXRInputActions.leftTriggerTouched != null)
            {
                left.L_TrigTouched = OpenXRInputActions.leftTriggerTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftThumbStickPressed != null)
            {
                left.L_JoyPressed = OpenXRInputActions.leftThumbStickPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftThumbStickTouched != null)
            {
                left.L_JoyTouched = OpenXRInputActions.leftThumbStickTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.leftThumbStickMove != null)
            {
                left.L_JoyX = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.x;
            }


            if (OpenXRInputActions.leftThumbStickMove != null)
            {
                left.L_JoyY = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.y;
            }


            if (OpenXRInputActions.leftGripPressed != null)
            {
                left.L_GripPressed = OpenXRInputActions.leftGripPressed.action.ReadValue<float>() == 1;
            }


            if (LeftController != null)
            {
                left.L_PosX = LeftController.transform.position.normalized.x;
                left.L_PosY = LeftController.transform.position.normalized.y;
                left.L_PosZ = LeftController.transform.position.normalized.z;
                left.L_RotX = LeftController.transform.rotation.normalized.x;
                left.L_RotY = LeftController.transform.rotation.normalized.y;
                left.L_RotZ = LeftController.transform.rotation.normalized.z;

            }



            if (OpenXRInputActions.rightSystemPressed != null)
            {
                right.R_BtnSysPress = OpenXRInputActions.rightSystemPressed.action.ReadValue<float>() == 1;
            }

            if (OpenXRInputActions.rightPrimaryButtonPressed != null)
            {
                right.R_BtnAPressed = OpenXRInputActions.rightPrimaryButtonPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightPrimaryButtonTouched != null)
            {
                right.R_BtnATouched = OpenXRInputActions.rightPrimaryButtonTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightSecondaryButtonPressed != null)
            {
                right.R_BtnBPressed = OpenXRInputActions.rightSecondaryButtonPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightSecondaryButtonTouched != null)
            {
                right.R_BtnBTouched = OpenXRInputActions.rightSecondaryButtonTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightTriggerPressed != null)
            {
                right.R_TrigPressed = OpenXRInputActions.rightTriggerPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightTriggerPressedValue != null)
            {
                right.R_TrigValue = OpenXRInputActions.rightTriggerPressedValue.action.ReadValue<float>();
            }


            if (OpenXRInputActions.rightTriggerTouched != null)
            {
                right.R_TrigTouched = OpenXRInputActions.rightTriggerTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightThumbStickPressed != null)
            {
                right.R_JoyPressed = OpenXRInputActions.rightThumbStickPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightThumbStickTouched != null)
            {
                right.R_JoyTouched = OpenXRInputActions.rightThumbStickTouched.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightGripPressed != null)
            {
                right.R_GripPressed = OpenXRInputActions.rightGripPressed.action.ReadValue<float>() == 1;
            }


            if (OpenXRInputActions.rightThumbStickMove != null)
            {
                right.R_JoyX = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.x;
            }

            if (OpenXRInputActions.rightThumbStickMove != null)
            {
                right.R_JoyY = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.y;
            }

            if (RightController != null)
            {

                //Pozycja
                double rightConX = RightController.transform.position.x - HeadPositionin2D.x;
                double rightConZ = RightController.transform.position.z - HeadPositionin2D.y;
                double y = RightController.transform.position.y;
                double xPoObrocie = rightConX * macierzRotacji[0, 0] - rightConZ * macierzRotacji[0, 1];
                double zPoObrocie = rightConX * macierzRotacji[1, 0] + rightConZ * macierzRotacji[1, 1];
                double xPoNormalizacji = xPoObrocie / (wysokoscGracza / 2);
                double zPoNormalizacji = zPoObrocie / (wysokoscGracza / 2);
                double yPoNormalizacji = y / (wysokoscGracza / 2);
                Debug.Log($"Pozycja prawego kontrolera znormalizowana: X: {xPoNormalizacji}\n Z: {zPoNormalizacji}\n Y: {yPoNormalizacji}, a nie znormalizowana: X: {RightController.transform.position.x}\n Z: {RightController.transform.position.z}\n Y: {RightController.transform.position.y}");

                right.R_PosX = xPoNormalizacji;
                right.R_PosY = yPoNormalizacji;
                right.R_PosZ = zPoNormalizacji;

                //Rotation
                right.R_RotX = RightController.transform.rotation.normalized.x;

                right.R_RotY = RightController.transform.rotation.normalized.y;

                right.R_RotZ = RightController.transform.rotation.normalized.z;

            }

            if (HeadController != null)
            {

                head.H_PosX = HeadController.transform.position.normalized.x;

                head.H_PosY = HeadController.transform.position.normalized.y;

                head.H_PosZ = HeadController.transform.position.normalized.z;

                head.H_RotX = HeadController.transform.rotation.normalized.x;

                head.H_RotY = HeadController.transform.rotation.normalized.y;

                head.H_RotZ = HeadController.transform.rotation.normalized.z;

            }

            record.LeftController = left;
            record.RightController = right;
            record.Head = head;


            record.TimeSpan = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) - StartRecordingTime;


            //Write to csv
            WriteRecordToCSV(record, ref csvstream);

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
        internal void WriteHeaderToJSONFile()
        {
            throw new NotImplementedException();

            //TODO: Dodać początek i koniec pliku JSON z tytułem data
        }

        internal void WriteObjectToJson(object obj, ref StreamWriter stream)
        {
            if (obj.GetType() == typeof(string))
            {
                string recordStringy = (string)obj;
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
        internal void WriteRecordToCSV(Record record, ref CsvWriter stream)
        {
            stream.WriteRecord(record);
            stream.NextRecord();
        }

        // Import data
        internal void ImportSequenceFromFile(string filePath)
        {
            throw new NotImplementedException();
        }


    }
}
