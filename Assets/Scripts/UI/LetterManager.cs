using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public TextMeshProUGUI textPro;

    private static LetterManager _instance;
    public static LetterManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    public static void setText(string pText)
    {
        Instance.textPro.text = pText;
    }
}
