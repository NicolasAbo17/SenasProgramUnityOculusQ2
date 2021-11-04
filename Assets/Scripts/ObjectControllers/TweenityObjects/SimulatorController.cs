//
//  SimulatorController.cs
//  Tweenity
//
//  Created by Vivian Gómez.
//  Copyright © 2021 Vivian Gómez - Pablo Figueroa - Universidad de los Andes
//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimulatorController : MonoBehaviour
{
    // Internal
    private int actualLetter;
    private bool isLearning;
    [HideInInspector]
    public List<Gesture> gestures;
    private int points = 0;

    // External
    [SerializeField]
    private LetterMenu letterMenu;
    [SerializeField]
    private GestureDetector gestureDetector;

    private static SimulatorController _instance;
    public static SimulatorController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SimulatorController>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        actualLetter = -1;
        gestures = FileHandler.ReadListFromJSON<Gesture>("Assets/Resources/Gestures/testLetters.json");

        gestureDetector.enabled = true;
        
        DontDestroyOnLoad(gameObject);
    }

    public void ShowReminder(object countdown, object activeObject, object audioName)
    {
        GameObject.Find("Reminder").GetComponent<ReminderController>().MoveOverObject(activeObject.ToString().Trim());
        if(audioName.ToString() != ""){VoiceController.PlayVoice(audioName.ToString());}
    }

    public void TimeOut(object countdown)
    {
        //Acá se puede incluir una implementación personalizada del timeout
    }

    public int Wait(object time)
    {
        return Convert.ToInt32(time)*1000;
    }

    public void InitializeAudiosDirectory(string dirAudio)
    {
        SimulationController.currentDirectoryAudios = dirAudio;
    }

    public int Play(object audioName)
    {
        return VoiceController.PlayVoice(audioName.ToString());
    }

    public void SetTraining()
    {
        isLearning = false;
        for (int i = 0; i < gestures.Count; i++)
        {
            Gesture temp = gestures[i];
            int randomIndex = UnityEngine.Random.Range(i, gestures.Count);
            gestures[i] = gestures[randomIndex];
            gestures[randomIndex] = temp;
        }

    }

    public void SetLearning()
    {
        isLearning = true;
    }
    public void StartRecognizing()
    {
        gestureDetector.enabled = true;
    }

    public void ShowNextLetter()
    {
        if(actualLetter < gestures.Count)
        {
            actualLetter++;
            letterMenu.ShowLetter(gestures[actualLetter].name);
            gestureDetector.gestureRecognizing = gestures[actualLetter];
            gestureDetector.SetRecognizing();
        }
        else
        {
            FinishActivity();
        }

        /*if (actualLetter > gestures.Count)
        {
            FinishActivity();
        }*/
    }

    public void RecognizeLetter()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "RecognizeLetter", ""));
        letterMenu.StopCountdown();
        points++;
    }

    public void FinishActivity()
    {
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "FinishActivity", ""));
    }

    public int GetTimeLeft()
    {
        return (int)gestureDetector.GetTimeLeft();
    }
}
