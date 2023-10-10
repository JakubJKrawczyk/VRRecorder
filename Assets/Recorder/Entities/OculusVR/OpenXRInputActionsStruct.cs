using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Recorder.DataModels.OpenXR
{
    [Serializable]
    public struct OpenXRInputActionsStruct
    {
        
        [Header("Input Action References For Left Controller")]
        [Space]
        [FormerlySerializedAs("LeftPrimaryButtonPressed")] public InputActionReference leftPrimaryButtonPressed;
        [FormerlySerializedAs("LeftPrimaryButtonTouched")] public InputActionReference leftPrimaryButtonTouched;
        [FormerlySerializedAs("LeftSecondaryButtonPressed")] public InputActionReference leftSecondaryButtonPressed;
        [FormerlySerializedAs("LeftSecondaryButtonTouched")] public InputActionReference leftSecondaryButtonTouched;
        [FormerlySerializedAs("LeftMenuPressed")] public InputActionReference leftMenuPressed;
        [FormerlySerializedAs("LeftTriggerPressed")] public InputActionReference leftTriggerPressed;
        [FormerlySerializedAs("LeftTriggerPressedValue")] public InputActionReference leftTriggerPressedValue;
        [FormerlySerializedAs("LeftTriggerTouched")] public InputActionReference leftTriggerTouched;
        [FormerlySerializedAs("LeftThumbStickPressed")] public InputActionReference leftThumbStickPressed;
        [FormerlySerializedAs("LeftThumbStickTouched")] public InputActionReference leftThumbStickTouched;
        [FormerlySerializedAs("LeftThumbStickMove")] public InputActionReference leftThumbStickMove;
        [FormerlySerializedAs("LeftGripPressed")] public InputActionReference leftGripPressed;
        [Space]
        [Header("Input Action References For Left Controller")]
        [Space]
        [FormerlySerializedAs("RightPrimaryButtonPressed")] public InputActionReference rightPrimaryButtonPressed;
        [FormerlySerializedAs("RightPrimaryButtonTouched")] public InputActionReference rightPrimaryButtonTouched;
        [FormerlySerializedAs("RightSecondaryButtonPressed")] public InputActionReference rightSecondaryButtonPressed;
        [FormerlySerializedAs("RightSecondaryButtonTouched")] public InputActionReference rightSecondaryButtonTouched;
        [FormerlySerializedAs("RightSystemPressed")] public InputActionReference rightSystemPressed;
        [FormerlySerializedAs("RightTriggerPressed")] public InputActionReference rightTriggerPressed;
        [FormerlySerializedAs("RightTriggerPressedValue")] public InputActionReference rightTriggerPressedValue;
        [FormerlySerializedAs("RightTriggerTouched")] public InputActionReference rightTriggerTouched;
        [FormerlySerializedAs("RightThumbStickPressed")] public InputActionReference rightThumbStickPressed;
        [FormerlySerializedAs("RightThumbStickTouched")] public InputActionReference rightThumbStickTouched;
        [FormerlySerializedAs("RightThumbStickMove")] public InputActionReference rightThumbStickMove;
        [FormerlySerializedAs("RightGripPressed")] public InputActionReference rightGripPressed;
    }
}
