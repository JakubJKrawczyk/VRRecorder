using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct RightControllerVREntity
    {
        public RightControllerVREntity(
            double posX = 0,
            double posY = 0,
            double posZ = 0,
            double rotX = 0,
            double rotY = 0,
            double rotZ = 0,
            bool gripPressed = false,
            bool trigPressed = false,
            double trigPressedValue = 0,
            bool trigTouched = false,
            bool thumbstickPressed = false,
            bool thumbstickTouched = false,
            double thumbstickX = 0,
            double thumbstickY = 0,
            bool btnAPressed = false,
            bool btnATouched = false,
            bool btnBPressed = false,
            bool btnBTouched = false,
            bool btnSysPress = false
        )
        {
            R_BtnAPressed = btnAPressed;
            R_BtnATouched = btnATouched;
            R_BtnBPressed = btnBPressed;
            R_BtnBTouched = btnBTouched;
            R_BtnSysPress = btnSysPress;
            R_GripPressed = gripPressed;
            R_TrigPressed = trigPressed;
            R_TrigValue = trigPressedValue;
            R_TrigTouched = trigTouched;
            R_JoyPressed = thumbstickPressed;
            R_JoyTouched = thumbstickTouched;
            R_JoyX = thumbstickX;
            R_JoyY = thumbstickY;
            R_PosX = posX;
            R_PosY = posY;
            R_PosZ = posZ;
            R_RotX = rotX;
            R_RotY = rotY;
            R_RotZ = rotZ;
        }

        // Buttons
        public bool R_BtnAPressed { get; set; }
        public bool R_BtnATouched { get; set; }
        public bool R_BtnBPressed { get; set; }
        public bool R_BtnBTouched { get; set; }
        public bool R_BtnSysPress { get; set; }
        public bool R_GripPressed { get; set; }
        public bool R_TrigPressed { get; set; }
        public double R_TrigValue { get; set; }
        public bool R_TrigTouched { get; set; }
        public bool R_JoyPressed { get; set; }
        public bool R_JoyTouched { get; set; }
        public double R_JoyX { get; set; }
        public double R_JoyY { get; set; }

        // Transform parameters
        public double R_PosX { get; set; }
        public double R_PosY { get; set; }
        public double R_PosZ { get; set; }
        public double R_RotX { get; set; }
        public double R_RotY { get; set; }
        public double R_RotZ { get; set; }
    }
}