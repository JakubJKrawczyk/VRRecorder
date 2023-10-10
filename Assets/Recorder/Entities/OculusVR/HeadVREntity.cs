using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct HeadVREntity
    {

        internal double PosX { get; set; }
        internal double PosY { get; set; }
        internal double PosZ { get; set; }
        internal double RotX { get; set; }
        internal double RotY { get; set; }
        internal double RotZ { get; set; }

        internal HeadVREntity(
            double positionX = 0,
            double positionY = 0,
            double positionZ = 0,
            double rotationX = 0,
            double rotationY = 0,
            double rotationZ = 0
        )
        {
            PosX = positionX;
            PosY = positionY;
            PosZ = positionZ;
            RotX = rotationX;
            RotY = rotationY;
            RotZ = rotationZ;
        }

        
    }
}
