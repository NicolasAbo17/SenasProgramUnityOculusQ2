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

    public List<Gesture> gestures;
    private float points = 0f;

    // External
    [SerializeField]
    private LetterMenu letterMenu;
    [SerializeField]
    private ScoreMenu scoreMenu;
    [SerializeField]
    private GestureDetector gestureDetector;

    // IsTest
    public bool isTest = false;

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
        /*
        // SOLO EN PC FUNCIONA, UTILIZARLO PARA DESARROLLO, LOS GESTOS DEBEN ESTAR GUARDADOS EN LA ESCENA PARA SU RESPECTIVO BUILD EN OCULUS
        if (isTest)
        {
            gestures = FileHandler.ReadListFromJSON<Gesture>("Assets/Resources/Gestures/testLetters.json");
        }
        else
        {
            gestures = FileHandler.ReadListFromJSON<Gesture>("Assets/Resources/Gestures/letters.json");
        }*/
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
        Debug.Log("Training");
    }

    public void SetLearning()
    {
        isLearning = true;
        gestures.Sort((g1, g2) => g1.name.CompareTo(g2.name));
        Debug.Log("Learning");
    }

    public void StartRecognizing()
    {
        gestureDetector.enabled = true;
    }

    public void ShowNextLetter()
    {
        actualLetter++; 
        if (actualLetter < gestures.Count)
        {
            Debug.Log("Next " + gestures[actualLetter].name);
            if (isLearning)
            {
                letterMenu.ShowImage(gestures[actualLetter].name);
            }
            else
            {
                letterMenu.ShowLetter(gestures[actualLetter].name);
            }
            gestureDetector.gestureRecognizing = gestures[actualLetter];
            gestureDetector.SetRecognizing();
        }
        else
        {
            Debug.Log("Finish");
            actualLetter = -1;
            letterMenu.Reset();
            if (isLearning)
            {
                EndExercise();
            }
            else
            {
                ShowScore();
            }

            points = 0;
        }

        /*if (actualLetter > gestures.Count)
        {
            FinishActivity();
        }*/
    }

    public void RecognizeLetter()
    {
        points++;
        letterMenu.StopCountdown();
        ShowNextLetter();
    }

    public void ShowScore()
    {
        scoreMenu.SetTitle("Tu puntación fue de:");
        scoreMenu.ShowScore(points + "/" + gestures.Count);
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "ShowScore", ""));
    }

    public void EndExercise()
    {
        scoreMenu.SetTitle("Practicaste correctamente este número de letras:");
        scoreMenu.ShowScore(points + " / " + gestures.Count);
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, "EndExercise", ""));
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public int GetTimeLeft()
    {
        return (int)gestureDetector.GetTimeLeft();
    }
}
