using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.IO;

// struct = class without functions
[System.Serializable]
public struct Gesture
{
    public char name;
    public List<Vector3> fingerDatas;
    public float threshold;
}

public class GestureDetector : MonoBehaviour
{
    // How much accurate the recognize should be
    private float threshold = 0.1f;
    
    [Header("Recognition Threshold value")]
    public float recognitionThreshold;

    // Add the component that refer to the skeleton hand ("OVRCustomHandPrefab_R" or "OVRCustomHandPrefab_L")
    [Header("Hand Skeleton")]
    public OVRSkeleton skeleton;

    // List of bones took from the OVRSkeleton
    private List<OVRBone> fingerbones = null;

    // Other boolean to check if are working correctly
    private bool hasStarted = false;
    private bool done = false;

    // Add an event if you want to make happen when a gesture is not identified
    [Header("Not Recognized Event")]
    public UnityEvent notRecognize;

    [Header("Recognizing Event")]
    public UnityEvent recognizing;

    // Recognition
    [HideInInspector]
    public bool isRecognizing = false;

    [HideInInspector]
    public Gesture gestureRecognizing;

    public float totalTime = 5f;
    private float timeRecognizing;

    void Start()
    {
        threshold = gestureRecognizing.threshold;
        timeRecognizing = totalTime;
        StartCoroutine(DelayRoutine(2.5f, Initialize));
    }

    // Coroutine used for delay some function
    public IEnumerator DelayRoutine(float delay, Action actionToDo)
    {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public void Initialize()
    {
        SetSkeleton();

        hasStarted = true;
    }
    public void SetSkeleton()
    {
        fingerbones = new List<OVRBone>(skeleton.Bones);
    }

    void Update()
    {
        /*if ( Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }*/

        if (hasStarted && isRecognizing)
        {
            bool hasRecognize = RecognizeLetter();

            if (hasRecognize)
            {
                done = true;
                if (timeRecognizing == totalTime)
                {
                    Debug.Log("First time " + gestureRecognizing.name);
                    recognizing?.Invoke();
                    threshold = recognitionThreshold;
                }
                timeRecognizing -= Time.deltaTime;
                if (timeRecognizing <= 0f)
                {
                    Debug.Log("Last time " + gestureRecognizing.name);

                    notRecognize?.Invoke();
                    isRecognizing = false;
                    timeRecognizing = totalTime;
                    SimulatorController.Instance.RecognizeLetter();
                }
            }
            else
            {
                if (done)
                {
                    notRecognize?.Invoke();
                    threshold = gestureRecognizing.threshold;
                    timeRecognizing = totalTime;

                    done = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                fingerbones = new List<OVRBone>(skeleton.Bones);
                Save();
                SimulatorController.Instance.gestures.RemoveAt(SimulatorController.Instance.gestures.Count - 1);
            }
        }
    }

   

    bool RecognizeLetter()
    {
        for (int i = 0; i < fingerbones.Count; i++)
        {
            Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);
            float distance = Vector3.Distance(currentData, gestureRecognizing.fingerDatas[i]);

            if (distance > threshold)
            {
                return false;
            }
        }
        return true;
    }




   void Save()
   {
       Gesture g = new Gesture();
       g.name = '_';

       List<Vector3> data = new List<Vector3>();
       foreach (var bone in fingerbones)
       {
           data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
       }

       g.fingerDatas = data;
       SimulatorController.Instance.gestures.Add(g);
   }

    public void SetRecognizing()
    {
        threshold = gestureRecognizing.threshold;
        timeRecognizing = totalTime;
        isRecognizing = true;
    }

    public float GetTimeLeft()
    {
        return timeRecognizing;
    }
    /*
    Gesture Recognize()
   {
       Gesture currentGesture = new Gesture();
       float currentMin = Mathf.Infinity;

       foreach (var gesture in SimulatorController.Instance.gestures)
       {
           float sumDistance = 0;
           bool isDiscarded = false;

           for (int i = 0; i < fingerbones.Count; i++)
           {
               Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);
               float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);

               if (distance > threshold)
               {
                   isDiscarded = true;
                   break;
               }
               sumDistance += distance;
           }

           if (!isDiscarded && sumDistance < currentMin)
           {
               currentMin = sumDistance;
               currentGesture = gesture;
           }
       }

       return currentGesture;
   }
    */
}
