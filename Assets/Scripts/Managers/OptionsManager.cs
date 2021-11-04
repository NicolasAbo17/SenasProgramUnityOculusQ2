using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject initialBtns;
    [SerializeField]
    private GameObject continueBtn;
    [SerializeField]
    private GameObject bigPanel;
    [SerializeField]
    private GameObject smallPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInitialBtns()
    {
        initialBtns.SetActive(!initialBtns.activeInHierarchy);
    }

    public void ToggleContinueBtns()
    {
        continueBtn.SetActive(!continueBtn.activeInHierarchy);
    }

    public void ToggleBigPanel()
    {
        bigPanel.SetActive(!bigPanel.activeInHierarchy);
    }

    public void ToggleSmallPanel()
    {
        smallPanel.SetActive(!smallPanel.activeInHierarchy);
    }
}
