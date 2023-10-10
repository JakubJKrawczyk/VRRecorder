using Assets.Recorder;
using Assets.Recorder.DataModels.OpenXR;
using System;
using System.Collections;
using Recorder;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using CsvHelper;
using System.Globalization;


public class VRRecorder : MonoBehaviour
{



    /*
     * Klasa powinna przechowywaæ:
     * - referencje do zestawu VR ( sprawdzaæ jakie elementy zestawu s¹ dostêpne i w jakiej konfiguracji
     * - instancje DataManagera
     * - wizualizacje nagranej sekwencji
     * - mo¿liwoœæ ustawienia czêstotliwoœci nagrywanej sekwencji -> Done
     * 
     * 
     */

    bool isRecording = false;
    DataManager _manager;

    // Displayed properties
    [Header("Paste directory path to save file")]
    [SerializeField]
    string filePath;
    [Space]
    [Header("Choose which data you want to record?:")]
    [SerializeField]
    float RecordFrequency = 1f;
    [SerializeField]
    private RecorderConfigurationStruct Configuration = new();

    // input binding
    [Header("Input Actions Binding")]
    [SerializeField]
    private OpenXRInputActionsStruct OpenXRInputActionsStruct = new();

    [Header("Reference to VRDevices GameObjects")]
    [SerializeField]
    private GameObject LeftController;
    [SerializeField]
    private GameObject RightController;
    [SerializeField]
    private GameObject HeadController;


    //Private props

    private StreamWriter _streamWriter;
    private CsvWriter _csvWriter;

    //Coroutine properties

    Coroutine coroutine;

    


    // Start is called before the first frame update
    void Start()
    {
        _manager = new();

        
        OpenXRInputActionsStruct.leftSecondaryButtonPressed.action.performed += (callback) =>
        {
            if (OpenXRInputActionsStruct.leftPrimaryButtonPressed.action.ReadValue<float>() == 1)
            {
                if (!isRecording)
                {

                StartRecording();
                }
                else
                {
                    StopRecording();
                }
            }
        };

        OpenXRInputActionsStruct.leftSecondaryButtonPressed.action.actionMap.asset.Enable();

        Debug.Log("Recorder Initialized");
    }

    

    public void StartRecording()
    {
        
        if(isRecording == false)
        {

            Debug.Log("Recording started");
            // If Record Started From Code
            _manager.Configuration = Configuration;

            _manager.OpenXRInputActions = OpenXRInputActionsStruct;
            _manager.LeftController = LeftController == null ? null : LeftController;
            _manager.RightController = RightController == null ? null : RightController;
            _manager.HeadController = HeadController == null ? null : HeadController;
            _manager.StartRecordingTime = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            
            isRecording = true;
            DateTime recordD = DateTime.Now;


            string dirPath = Path.Combine(filePath, $"/Records/Record-{recordD.Year}-{recordD.Month}-{recordD.Day}-{recordD.Hour}-{recordD.Minute}-{recordD.Second}");
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            string recordFilePath = Path.Combine(dirPath, $"record-{recordD.Hour}-{recordD.Minute}-{recordD.Second}.csv");
            Debug.Log("Recording Path: " + recordFilePath);

            _streamWriter = new(recordFilePath)
            {
                AutoFlush = true
            };

            _csvWriter = new(_streamWriter, CultureInfo.InvariantCulture);
            
            //JSON


            // CSV


            _manager.WriteHeaderToCsvFile(ref _csvWriter);

            
            //Coroutine
            coroutine = StartCoroutine(Record(RecordFrequency));
            
        }


    }

   



    public void StopRecording()
    {
        if (isRecording)
        {
            Debug.Log("Recording stopped");
            isRecording = false;
            StopCoroutine(coroutine);
            _csvWriter?.Dispose();
            _streamWriter?.Close();
            _streamWriter?.Dispose();


        }
    }

    IEnumerator Record(float secs)
    {

        while(true)
        {
            _manager.AddRecord(ref _streamWriter, ref _csvWriter);
            Debug.Log("Record Added");
            yield return new WaitForSeconds(secs);
        }
    }
}

////Custom Unity Editor for Recorder
//[CustomEditor(typeof(VRRecorder))]
//public class VRRecorderCustomEditor : Editor
//{

//}
