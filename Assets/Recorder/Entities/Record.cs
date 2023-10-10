using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recorder.Entities.OculusVR;

namespace Assets.Recorder.DataModels
{
    [Serializable]
    internal class Record
    {
        internal HeadVREntity Head { get; set; }
        internal LeftControllerVREntity LeftController { get; set; }
        internal RightControllerVREntity RightController { get; set; }
        internal TimeSpan TimeSpan { get; set; }

        internal Record()
        {
            Head = new();
            LeftController = new LeftControllerVREntity();
            RightController = new RightControllerVREntity();
            TimeSpan = new TimeSpan();
        }

        
    }
}
