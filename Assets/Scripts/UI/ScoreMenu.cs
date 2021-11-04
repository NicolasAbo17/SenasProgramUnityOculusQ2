using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleTxt;
    [SerializeField]
    private TextMeshProUGUI scoreTxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SetTitle(string title)
    {
        titleTxt.text = title;
    }

    internal void ShowScore(string score)
    {
        scoreTxt.text = score;
    }
}
