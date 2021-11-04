using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject initialMenu;

    [SerializeField]
    private GameObject descriptionMenu;

    [SerializeField]
    private GameObject letterMenu;

    [SerializeField]
    private GameObject pointMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInitialMenu()
    {
        initialMenu.SetActive(!initialMenu.activeInHierarchy);
    }

    public void ToggleDescriptionMenu()
    {
        descriptionMenu.SetActive(!descriptionMenu.activeInHierarchy);
    }

    public void ToggleLetterMenu()
    {
        letterMenu.SetActive(!letterMenu.activeInHierarchy);
    }

    public void TogglePointMenu()
    {
        pointMenu.SetActive(!pointMenu.activeInHierarchy);
    }
}
