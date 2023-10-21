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
using Assets.Recorder.Mappers;


public class VRRecorder : MonoBehaviour
{



    /*
     * Klasa powinna przechowywaæ:
     * - wizualizacje nagranej sekwencji
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

    [SerializeField]
    float RecordFrequency = 1f;


    // input binding
    [Header("Input Actions Binding")]
    [SerializeField]
    private OpenXRInputActionsStruct OpenXRInputActionsStruct = new();

    [Header("Reference to VRDevices GameObjects and Floor")]
    [SerializeField]
    private GameObject LeftController;
    [SerializeField]
    private GameObject RightController;
    [SerializeField]
    private GameObject HeadController;
    [SerializeField]
    private GameObject Floor;

    //Private props

    private StreamWriter _streamWriter;
    private CsvWriter _csvWriter;

    //Coroutine properties

    Coroutine coroutine;




    // Start is called before the first frame update
    void Start()
    {
        _manager = new();
        if (Floor != null)
        {
            _manager.floorHeight = Floor.transform.position.y;

        }
        _manager.OpenXRInputActions = OpenXRInputActionsStruct;
        _manager.LeftController = LeftController == null ? null : LeftController;
        _manager.RightController = RightController == null ? null : RightController;
        _manager.HeadController = HeadController == null ? null : HeadController;
        _manager.SetNormalizationProperties();

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

        if (isRecording == false)
        {

            Debug.Log("Recording started");
            // If Record Started From Code



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


            //Stream initialize
            _streamWriter = new(recordFilePath)
            {
                AutoFlush = true
            };

            _csvWriter = new(_streamWriter, CultureInfo.InvariantCulture);
            _csvWriter.Context.RegisterClassMap(OculusRecordMapper.CreateMap());

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

        while (true)
        {
            _manager.AddRecord(ref _streamWriter, ref _csvWriter);
            yield return new WaitForSeconds(secs);
        }
    }
}

////Custom Unity Editor for Recorder
//[CustomEditor(typeof(VRRecorder))]
//public class VRRecorderCustomEditor : Editor
//{

//}
