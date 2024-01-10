using VRParser.Entities.OculusVR;

namespace VRParser.Entities
{
    [Serializable]
    public class Record
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