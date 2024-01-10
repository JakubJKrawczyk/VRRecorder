using System;
using System.Collections;
using System.Globalization;
using System.IO;
using Assets.Recorder.DataModels.OpenXR;
using Assets.Recorder.Mappers;
using CsvHelper;
using Recorder;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRRecorder : MonoBehaviour
{
    // Displayed properties
    [Header("Paste directory path to save file")] [SerializeField]
    private string filePath;

    [Space] [SerializeField] private float RecordFrequency = 1f;


    // input binding
    [Header("Input Actions Binding")] 
    
    [SerializeField] private OpenXRInputActionsStruct OpenXRInputActionsStruct;
    [Header("Position")] 
    [SerializeField] private InputActionReference leftController;

     [SerializeField] private InputActionReference rightController;

     [SerializeField] private InputActionReference headController;
     
     [Header("Rotation")] 
    
     [Header("Floor")] 
    [SerializeField] private GameObject Floor;

    private CsvWriter _csvWriter;
    private DataManager _manager;

    //Private props

    private StreamWriter _streamWriter;

    //Coroutine properties

    private Coroutine coroutine;


    /*
     * Klasa powinna przechowywać:
     * - wizualizacje nagranej sekwencji
     *
     *
     */

    public static bool isRecording { get; set; }


    // Start is called before the first frame update
    private void Start()
    {
        _manager = new DataManager();

        _manager.OpenXRInputActions = OpenXRInputActionsStruct;
        _manager.LeftController = leftController == null ? null : leftController.action.actionMap;
        _manager.RightController = rightController == null ? null : rightController.action.actionMap;
        _manager.HeadController = headController == null ? null : headController.action.actionMap;


        OpenXRInputActionsStruct.leftSecondaryButtonPressed.action.performed += _ =>
        {
            var TOLERANCE = 0.00001;
            if (Math.Abs(OpenXRInputActionsStruct.leftPrimaryButtonPressed.action.ReadValue<float>() - 1) < TOLERANCE)
            {
                if (!isRecording)
                    StartRecording();
                else
                    StopRecording();
            }
        };

        OpenXRInputActionsStruct.leftSecondaryButtonPressed.action.actionMap.asset.Enable();

        Debug.Log("Recorder Initialized");
    }

    // private void Update()
    // {
    // }

    public void StartRecording()
    {
        if (Floor != null) _manager.floorHeight = Floor.transform.position.y;
        
        if (isRecording == false)
        {
            Debug.Log("Recording started");
            // If Record Started From Code


            _manager.StartRecordingTime = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond);

            isRecording = true;
            var recordD = DateTime.Now;


            var dirPath = Path.Combine(filePath,
                $"/Records/Record-{recordD.Year}-{recordD.Month}-{recordD.Day}-{recordD.Hour}-{recordD.Minute}-{recordD.Second}");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            var recordFilePath = Path.Combine(dirPath, $"record-{recordD.Hour}-{recordD.Minute}-{recordD.Second}.csv");
            Debug.Log("Recording Path: " + recordFilePath);


            //Stream initialize
            _streamWriter = new StreamWriter(recordFilePath)
            {
                AutoFlush = true
            };
            
            _csvWriter = new CsvWriter(_streamWriter, CultureInfo.InvariantCulture);
            _csvWriter.Context.RegisterClassMap(OculusRecordMapper.CreateMap());
        

            //Parameters initialize
            SetNormalizationData();
            //_manager.HeadPosition2D =new Vector2(HeadController.transform.position.x, HeadController.transform.position.z);

            //JSON


            // CSV


            _manager.WriteHeaderToCsvFile(ref _csvWriter);


            //Coroutine
            coroutine = StartCoroutine(Record(RecordFrequency));
        }
    }

    
    private void SetNormalizationData()
    {
       var pos = headController.action.actionMap["Position"];
        _manager.rotacjaHeadsetaWosiY = pos.ReadValue<Vector3>().y;
        _manager.macierzRotacji[0,0] = Math.Cos(_manager.rotacjaHeadsetaWosiY);
        _manager.macierzRotacji[1,0] = Math.Sin(_manager.rotacjaHeadsetaWosiY);
        _manager.macierzRotacji[0,1] = -Math.Sin(_manager.rotacjaHeadsetaWosiY);
        _manager.macierzRotacji[1,1] = Math.Cos(_manager.rotacjaHeadsetaWosiY);
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

    private IEnumerator Record(float secs)
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