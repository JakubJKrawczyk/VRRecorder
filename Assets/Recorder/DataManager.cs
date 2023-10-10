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
        // private props
        internal DataManager()
        {
        }
        internal void AddRecord(ref StreamWriter stream, ref CsvWriter csvstream)
        {
            Record record = new();
            LeftControllerVREntity left = new();
            RightControllerVREntity right = new();
            HeadVREntity head = new();
            if (Configuration.RecordLeftMenuPressed)
            {
                if (OpenXRInputActions.leftMenuPressed != null)
                {
                    left.ButtonMenuPressed = OpenXRInputActions.leftMenuPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftPrimaryButtonPressed)
            {
                if (OpenXRInputActions.leftPrimaryButtonPressed != null)
                {
                    left.ButtonXPressed = OpenXRInputActions.leftPrimaryButtonPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftPrimaryButtonTouched)
            {

                if (OpenXRInputActions.leftPrimaryButtonTouched != null)
                {
                    left.ButtonXTouched = OpenXRInputActions.leftPrimaryButtonTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftSecondaryButtonPressed)
            {

                if (OpenXRInputActions.leftSecondaryButtonPressed != null)
                {
                    left.ButtonYPressed = OpenXRInputActions.leftSecondaryButtonPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftSecondaryButtonTouched)
            {

                if (OpenXRInputActions.leftSecondaryButtonTouched != null)
                {
                    left.ButtonYTouched = OpenXRInputActions.leftSecondaryButtonTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftTriggerPressed)
            {

                if (OpenXRInputActions.leftTriggerPressed != null)
                {
                    left.TrigPressed = OpenXRInputActions.leftTriggerPressed.action.ReadValue<float>() == 1;
                    Debug.Log($"Trigger Press Added: {left.TrigPressed}");
                }
            }
            if (Configuration.RecordLeftTriggerPressedValue)
            {

                if (OpenXRInputActions.leftTriggerPressedValue != null)
                {
                    left.TrigValue = OpenXRInputActions.leftTriggerPressedValue.action.ReadValue<float>();
                }
            }
            if (Configuration.RecordLeftTriggerTouched)
            {

                if (OpenXRInputActions.leftTriggerTouched != null)
                {
                    left.TrigTouched = OpenXRInputActions.leftTriggerTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftThumbStickPressed)
            {

                if (OpenXRInputActions.leftThumbStickPressed != null)
                {
                    left.JoyPressed = OpenXRInputActions.leftThumbStickPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftThumbStickTouched)
            {

                if (OpenXRInputActions.leftThumbStickTouched != null)
                {
                    left.JoyTouched = OpenXRInputActions.leftThumbStickTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordLeftThumbStickMove)
            {

                if (OpenXRInputActions.leftThumbStickMove != null)
                {
                    left.JoyX = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.x;
                }
            }

            if (Configuration.RecordLeftThumbStickMove)
            {

                if (OpenXRInputActions.leftThumbStickMove != null)
                {
                    left.JoyY = OpenXRInputActions.leftThumbStickMove.action.ReadValue<Vector2>().normalized.y;
                }
            }

            if (Configuration.RecordLeftGripPressed)
            {

                if (OpenXRInputActions.leftGripPressed != null)
                {
                    left.GripPressed = OpenXRInputActions.leftGripPressed.action.ReadValue<float>() == 1;
                }
            }

            if (LeftController != null)
            {
                if (Configuration.RecordLeftPositionX)
                {


                    left.PosX = LeftController.transform.position.normalized.x;

                }
                if (Configuration.RecordLeftPositionY)
                {


                    left.PosY = LeftController.transform.position.normalized.y;

                }
                if (Configuration.RecordLeftPositionZ)
                {


                    left.PosZ = LeftController.transform.position.normalized.z;

                }
                if (Configuration.RecordLeftRotationX)
                {
                    left.RotX = LeftController.transform.rotation.normalized.x;
                }
                if (Configuration.RecordLeftRotationY)
                {
                    left.RotY = LeftController.transform.rotation.normalized.y;
                }
                if (Configuration.RecordLeftRotationZ)
                {
                    left.RotZ = LeftController.transform.rotation.normalized.z;
                }
            }


            if (Configuration.RecordRightSystemPressed)
            {
                if (OpenXRInputActions.rightSystemPressed != null)
                {
                    right.BtnSysPress = OpenXRInputActions.rightSystemPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightPrimaryButtonPressed)
            {
                if (OpenXRInputActions.rightPrimaryButtonPressed != null)
                {
                    right.BtnAPressed = OpenXRInputActions.rightPrimaryButtonPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightPrimaryButtonTouched)
            {

                if (OpenXRInputActions.rightPrimaryButtonTouched != null)
                {
                    right.BtnATouched = OpenXRInputActions.rightPrimaryButtonTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightSecondaryButtonPressed)
            {

                if (OpenXRInputActions.rightSecondaryButtonPressed != null)
                {
                    right.BtnBPressed = OpenXRInputActions.rightSecondaryButtonPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightSecondaryButtonTouched)
            {

                if (OpenXRInputActions.rightSecondaryButtonTouched != null)
                {
                    right.BtnBTouched = OpenXRInputActions.rightSecondaryButtonTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightTriggerPressed)
            {

                if (OpenXRInputActions.rightTriggerPressed != null)
                {
                    right.TrigPressed = OpenXRInputActions.rightTriggerPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightTriggerPressedValue)
            {

                if (OpenXRInputActions.rightTriggerPressedValue != null)
                {
                    right.TrigValue = OpenXRInputActions.rightTriggerPressedValue.action.ReadValue<float>();
                }
            }
            if (Configuration.RecordRightTriggerTouched)
            {

                if (OpenXRInputActions.rightTriggerTouched != null)
                {
                    right.TrigTouched = OpenXRInputActions.rightTriggerTouched.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightThumbStickPressed)
            {

                if (OpenXRInputActions.rightThumbStickPressed != null)
                {
                    right.JoyPressed = OpenXRInputActions.rightThumbStickPressed.action.ReadValue<float>() == 1;
                }
            }
            if (Configuration.RecordRightThumbStickTouched)
            {

                if (OpenXRInputActions.rightThumbStickTouched != null)
                {
                    right.JoyTouched = OpenXRInputActions.rightThumbStickTouched.action.ReadValue<float>() == 1;
                }
            }

            if (Configuration.RecordRightGripPressed)
            {

                if (OpenXRInputActions.rightGripPressed != null)
                {
                    right.GripPressed = OpenXRInputActions.rightGripPressed.action.ReadValue<float>() == 1;
                }
            }

            if (Configuration.RecordRightThumbStickMove)
            {

                if (OpenXRInputActions.rightThumbStickMove != null)
                {
                    right.JoyX = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.x;
                }
            }
            if (Configuration.RecordRightThumbStickMove)
            {

                if (OpenXRInputActions.rightThumbStickMove != null)
                {
                    right.JoyY = OpenXRInputActions.rightThumbStickMove.action.ReadValue<Vector2>().normalized.y;
                }
            }
            if (RightController != null)
            {
                if (Configuration.RecordRightPositionX)
                {


                    right.PosX = RightController.transform.position.normalized.x;

                }
                if (Configuration.RecordRightPositionY)
                {


                    right.PosY = RightController.transform.position.normalized.y;

                }
                if (Configuration.RecordRightPositionZ)
                {


                    right.PosZ = RightController.transform.position.normalized.z;

                }
                if (Configuration.RecordRightRotationX)
                {
                    right.RotX = RightController.transform.rotation.normalized.x;
                }
                if (Configuration.RecordRightRotationY)
                {
                    right.RotY = RightController.transform.rotation.normalized.y;
                }
                if (Configuration.RecordRightRotationZ)
                {
                    right.RotZ = RightController.transform.rotation.normalized.z;
                }
            }

            if (HeadController != null)
            {
                if (Configuration.RecordHeadPositionX)
                {
                    head.PosX = HeadController.transform.position.normalized.x;
                }
                if (Configuration.RecordHeadPositionY)
                {
                    head.PosY = HeadController.transform.position.normalized.y;
                }
                if (Configuration.RecordHeadPositionZ)
                {
                    head.PosZ = HeadController.transform.position.normalized.z;
                }
                if (Configuration.RecordHeadRotationX)
                {
                    head.RotX = HeadController.transform.rotation.normalized.x;
                }
                if (Configuration.RecordHeadRotationY)
                {
                    head.RotY = HeadController.transform.rotation.normalized.y;
                }
                if (Configuration.RecordHeadRotationZ)
                {
                    head.RotZ = HeadController.transform.rotation.normalized.z;
                }
            }

            record.LeftController = left;
            record.RightController = right;
            record.Head = head;


            record.TimeSpan = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) - StartRecordingTime;


            //Write to csv
            WriteRecordToCSV(record,ref csvstream);

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
