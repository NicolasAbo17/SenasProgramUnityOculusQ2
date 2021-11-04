using System;
using System.Collections.Generic;
using UnityEngine;

public class BtnsManager : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;

    private bool isTraining = false;

    public void ShowButtonBool(object btnName, object show, bool showIfIsTraining)
    {
        bool stateShow = (("" + showIfIsTraining) == "true")
                   ? true
                   : false;

        Debug.Log("Machete");

        if (isTraining == stateShow)
        {
            ShowButton(btnName, show);
        }
    }

    public void ShowButton(object btnName, object show)
    {
        Debug.Log("Miau");
        bool stateShow = ((""+show)=="true")
                    ? true
                    : false;

        switch (btnName)
        {
            case "button1":
                btn1.SetActive(stateShow);
                break;
            case "button2":
                btn2.SetActive(stateShow);
                break;
        }
    }

    public void setTest()
    {
        isTraining = false;
        Debug.Log("cortarselas");
    }

    public void startExercise()
    {
        Debug.Log("Start");
    }

}
