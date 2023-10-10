using System;
using System.Collections.Generic;
using Assets.Recorder.DataModels;

namespace Recorder.Entities
{
    [Serializable]
    public class Data
    {

        internal List<Record> RecordsSequence { get; set; }
        public Data()
        {
            RecordsSequence = new List<Record>();
        }

        public override string ToString()
        {

            string returnString = "";

            foreach (var record in RecordsSequence)
            {
                returnString += $"\nRecord {RecordsSequence.IndexOf(record)}\n" +
                    $"Head:\n" +
                    $"Position: ({record.Head.PosX}, {record.Head.PosY}, {record.Head.PosZ})\n" +
                    $"Rotation: ({record.Head.RotX}, {record.Head.RotY}, {record.Head.RotZ})\n" +
                    $"\n" +
                    $"LeftController: \n" +
                    $"Primary Button press: {record.LeftController.ButtonXPressed}\n" +
                    $"Primary Button touched: {record.LeftController.ButtonXTouched}\n" +
                    $"Secondary Button press: {record.LeftController.ButtonYPressed}\n" +
                    $"Secondary Button touched: {record.LeftController.ButtonYTouched}\n" +
                    $"Menu press: {record.LeftController.ButtonMenuPressed}\n" +
                    $"Trigger press: {record.LeftController.TrigPressed}\n" +
                    $"Trigger press value: {record.LeftController.TrigValue}\n" +
                    $"Trigger touched: {record.LeftController.TrigTouched}\n" +
                    $"Thumbstick press: {record.LeftController.JoyPressed}\n" +
                    $"Thumbstick touched: {record.LeftController.JoyTouched}\n" +
                    $"Thumbstick move: ({record.LeftController.JoyX},{record.LeftController.JoyY})\n";
            }
            return returnString;
        }
    }
}
