using System;
using TMPro;
using UnityEngine;

namespace Recorder.Tools
{
    public class DisplayControllerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI recordInfo;
        
        

        private void Update()
        {
            if (VRRecorder.isRecording)
            {
                recordInfo.color = Color.green;
                recordInfo.text = "Recording ON";
            }
            else
            {
                recordInfo.color = Color.red;
                recordInfo.text = "Recording OFF";
            } 
        }
    }
}