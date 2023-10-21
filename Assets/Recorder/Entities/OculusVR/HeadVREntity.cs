using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct HeadVREntity
    {

        public double H_PosX { get; set; }
        public double H_PosY { get; set; }
        public double H_PosZ { get; set; }
        public double H_RotX { get; set; }
        public double H_RotY { get; set; }
        public double H_RotZ { get; set; }
                       
        public HeadVREntity(
            double positionX = 0,
            double positionY = 0,
            double positionZ = 0,
            double rotationX = 0,
            double rotationY = 0,
            double rotationZ = 0
        )
        {
            H_PosX = positionX;
            H_PosY = positionY;
            H_PosZ = positionZ;
            H_RotX = rotationX;
            H_RotY = rotationY;
            H_RotZ = rotationZ;
        }

        
    }
}
