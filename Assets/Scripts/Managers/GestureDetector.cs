using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private OVRSkeleton skeleton;
    [SerializeField] private List<Gesture> gestures;
    [SerializeField] private LetterGesture[] letterGestures;
    [SerializeField] private bool debugMode = true;
    [SerializeField] private KeyCode keycode;
    private List<OVRBone> fingerBones;

    public char last = 'I';

    private Gesture emptyGesture;
    private Gesture previousGesture;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
        emptyGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode && Input.GetKeyDown(keycode))
        {
            Debug.Log("Saving");
            fingerBones = new List<OVRBone>(skeleton.Bones);
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(emptyGesture);

        if(hasRecognized && !currentGesture.Equals(previousGesture))
        {
            Debug.Log("New gesture found: " + currentGesture.name);
            previousGesture = currentGesture;
            currentGesture.onRecognized.Invoke();
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "" + last;
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            //finger position relative to root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);

        last++;
        Debug.Log(last);
    }

    Gesture Recognize()
    {
        Gesture currentgesture = emptyGesture;
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if(distance > threshold)
                {
                    isDiscarded = true;
                }

                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentgesture = gesture;
            }
        }

        return currentgesture;
    }
}