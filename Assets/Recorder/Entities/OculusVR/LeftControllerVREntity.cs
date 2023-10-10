using System;

namespace Recorder.Entities.OculusVR
{
    [Serializable]
    internal struct LeftControllerVREntity
    {
        // Buttons
        internal bool ButtonXPressed { get; set; }
        internal bool ButtonXTouched { get; set; }
        internal bool ButtonYPressed { get; set; }
        internal bool ButtonYTouched { get; set; }
        internal bool ButtonMenuPressed { get; set; }
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

        internal LeftControllerVREntity(
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
            ButtonXPressed = buttonXPressed;
            ButtonXTouched = buttonXTouched;
            ButtonYPressed = buttonYPressed; 
            ButtonYTouched = buttonYTouched; 
            ButtonMenuPressed = buttonMenuPressed;
            GripPressed = gripPressed;
            TrigPressed = trigPressed;
            TrigValue = trigPressedValue;
            TrigTouched = trigTouched;
            JoyPressed = thumbstickPressed;
            JoyTouched = thumbstickTouched;
            JoyX = thumbstickX;
            JoyY = thumbstickY;
            
            PosX = posX;
            PosY = posY;
            PosZ = posZ;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;


        }
        
    }
}
