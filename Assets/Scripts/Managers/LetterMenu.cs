using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI letterTxt;
    [SerializeField]
    private TextMeshProUGUI timeTxt;

    private bool isCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            timeTxt.text = SimulatorController.Instance.GetTimeLeft() + "";
        }
        
    }

    public void ShowLetter(char letter)
    {
        letterTxt.text = letter + "";
    }

    public void StartCountdown()
    {
        timeTxt.text = "5";
        isCounting = true;
    }

    public void StopCountdown()
    {
        isCounting = false;
        timeTxt.text = "";
    }
}
