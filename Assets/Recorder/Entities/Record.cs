using System;
using Recorder.Entities.OculusVR;

namespace Assets.Recorder.DataModels
{
    [Serializable]
    internal class Record
    {
        internal Record()
        {
            Head = new HeadVREntity();
            LeftController = new LeftControllerVREntity();
            RightController = new RightControllerVREntity();
            TimeSpan = new TimeSpan();
        }

        internal HeadVREntity Head { get; set; }
        internal LeftControllerVREntity LeftController { get; set; }
        internal RightControllerVREntity RightController { get; set; }
        internal TimeSpan TimeSpan { get; set; }
    }
}