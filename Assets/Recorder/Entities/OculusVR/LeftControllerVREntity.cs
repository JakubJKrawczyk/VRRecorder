using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct LeftControllerVREntity
    {
        public LeftControllerVREntity(
            // fields from this class
            bool buttonXPressed = false,
            bool buttonXTouched = false,
            bool buttonYPressed = false,
            bool buttonYTouched = false,
            bool buttonMenuPressed = false,

            // fields from inheritance
            bool gripPressed = false,
            bool trigPressed = false,
            double trigPressedValue = 0,
            bool trigTouched = false,
            bool thumbstickPressed = false,
            bool thumbstickTouched = false,
            double thumbstickX = 0,
            double thumbstickY = 0,
            double posX = 0,
            double posY = 0,
            double posZ = 0,
            double rotX = 0,
            double rotY = 0,
            double rotZ = 0
        )
        {
            // class extended constructor
            L_ButtonXPressed = buttonXPressed;
            L_ButtonXTouched = buttonXTouched;
            L_ButtonYPressed = buttonYPressed;
            L_ButtonYTouched = buttonYTouched;
            L_ButtonMenuPressed = buttonMenuPressed;
            L_GripPressed = gripPressed;
            L_TrigPressed = trigPressed;
            L_TrigValue = trigPressedValue;
            L_TrigTouched = trigTouched;
            L_JoyPressed = thumbstickPressed;
            L_JoyTouched = thumbstickTouched;
            L_JoyX = thumbstickX;
            L_JoyY = thumbstickY;

            L_PosX = posX;
            L_PosY = posY;
            L_PosZ = posZ;
            L_RotX = rotX;
            L_RotY = rotY;
            L_RotZ = rotZ;
        }

        // Buttons
        public bool L_ButtonXPressed { get; set; }
        public bool L_ButtonXTouched { get; set; }
        public bool L_ButtonYPressed { get; set; }
        public bool L_ButtonYTouched { get; set; }
        public bool L_ButtonMenuPressed { get; set; }
        public bool L_GripPressed { get; set; }
        public bool L_TrigPressed { get; set; }
        public double L_TrigValue { get; set; }
        public bool L_TrigTouched { get; set; }
        public bool L_JoyPressed { get; set; }
        public bool L_JoyTouched { get; set; }
        public double L_JoyX { get; set; }
        public double L_JoyY { get; set; }

        // Transform parameters
        public double L_PosX { get; set; }
        public double L_PosY { get; set; }
        public double L_PosZ { get; set; }
        public double L_RotX { get; set; }
        public double L_RotY { get; set; }
        public double L_RotZ { get; set; }
    }
}