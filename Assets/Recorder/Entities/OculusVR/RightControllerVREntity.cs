using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct RightControllerVREntity
    {
        // Buttons
        internal bool BtnAPressed { get; set; }
        internal bool BtnATouched { get; set; }
        internal bool BtnBPressed { get; set; }
        internal bool BtnBTouched { get; set; }
        internal bool BtnSysPress { get; set; }
        internal bool GripPressed { get; set; }
        internal bool TrigPressed { get; set; }
        internal double TrigValue { get; set; }
        internal bool TrigTouched { get; set; }
        internal bool JoyPressed { get; set; }
        internal bool JoyTouched { get; set; }
        internal double JoyX { get; set; }
        internal double JoyY { get; set; }

        // Transform parameters
        internal double PosX { get; set; }
        internal double PosY { get; set; }
        internal double PosZ { get; set; }
        internal double RotX { get; set; }
        internal double RotY { get; set; }
        internal double RotZ { get; set; }

        internal RightControllerVREntity(
            
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
            BtnAPressed = btnAPressed;
            BtnATouched = btnATouched;
            BtnBPressed = btnBPressed;
            BtnBTouched = btnBTouched;
            BtnSysPress = btnSysPress;
            GripPressed = gripPressed;
            TrigPressed = trigPressed;
            TrigValue = trigPressedValue;
            TrigTouched = trigTouched;
            JoyPressed = thumbstickPressed;
            JoyTouched = thumbstickTouched;
            JoyX = thumbstickX;
            JoyY = thumbstickY;
            PosX = 0;
            PosY = 0;
            PosZ = 0;
            RotX = 0;
            RotY = 0;
            RotZ = 0;
        }
    }
}
