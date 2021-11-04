using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject letterTxt;
    [SerializeField]
    private GameObject letterImg;
    [SerializeField]
    private GameObject timeTxt;

    public List<Sprite> images;

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
            timeTxt.GetComponent<TextMeshProUGUI>().text = SimulatorController.Instance.GetTimeLeft() + "";
        }
        
    }

    public void ShowImage(char letter)
    {
        letterTxt.SetActive(false);
        letterImg.SetActive(true);
        int spritePos = letter - 'A';
        letterImg.GetComponent<Image>().sprite = images[spritePos];
    }

    public void ShowLetter(char letter)
    {
        letterImg.SetActive(false);
        letterTxt.SetActive(true);
        letterTxt.GetComponent<TextMeshProUGUI>().text = letter + "";
    }

    public void StartCountdown()
    {
        timeTxt.GetComponent<TextMeshProUGUI>().text = "5";
        isCounting = true;
    }

    public void StopCountdown()
    {
        isCounting = false;
        timeTxt.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void Reset()
    {
        letterTxt.SetActive(false);
        letterImg.SetActive(false);
    }
}
