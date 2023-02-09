using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MenuManagerScript : MonoBehaviour
{
    private Keyboard myKB;
    [SerializeField] private GameObject startMenuObject;
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject settingsMenuObject;
    [SerializeField] private GameObject aboutMenuObject;
    [SerializeField] private TMP_Text buttonDemoText;
    [SerializeField] private GameObject spiderWebs;
    [SerializeField] private GameObject transitionEffectObject;
    [SerializeField] private GameObject pCControlsUI;
    [SerializeField] private GameObject xBoxControlsUI;
    private List<GameObject> menuObjects = new List<GameObject>();

    private void Awake()
    {
        myKB = Keyboard.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonDemoText.text = "";
        menuObjects.Add(startMenuObject);
        menuObjects.Add(pauseMenuObject);
        menuObjects.Add(settingsMenuObject);
        menuObjects.Add(aboutMenuObject);
        menuObjects.Add(pCControlsUI);
        menuObjects.Add(xBoxControlsUI);
        foreach(GameObject thing in menuObjects)
        {
            thing.SetActive(false);
        }
        spiderWebs.SetActive(false);
        transitionEffectObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (myKB.digit1Key.wasPressedThisFrame)
        {
            ShowMenu(startMenuObject);
        }

        if (myKB.digit2Key.wasPressedThisFrame)
        {
            ShowMenu(pauseMenuObject);
        }

        if (myKB.digit3Key.wasPressedThisFrame)
        {
            ShowMenu(settingsMenuObject);
        }

        if (myKB.digit4Key.wasPressedThisFrame)
        {
            ShowMenu(aboutMenuObject);
        }

        if(myKB.shiftKey.isPressed && myKB.pKey.wasPressedThisFrame)
        {
            ShowMenu(pCControlsUI);
        }

        if (myKB.shiftKey.isPressed && myKB.xKey.wasPressedThisFrame)
        {
            ShowMenu(xBoxControlsUI);
        }

        if (myKB.escapeKey.wasPressedThisFrame)
        {
            HideMenus();
        }
    }

   private void ShowMenu(GameObject menuToShow)
    {
        if (!menuToShow.activeInHierarchy)
        {
            transitionEffectObject.SetActive(false);
            foreach(GameObject thing in menuObjects)
            {
                thing.SetActive(false);
            }
            transitionEffectObject.SetActive(true);
            spiderWebs.SetActive(true);
            menuToShow.SetActive(true);
        }
    }

    private void HideMenus()
    {
        transitionEffectObject.SetActive(true);
        foreach(GameObject thing in menuObjects)
        {
            thing.SetActive(false);
        }
        transitionEffectObject.SetActive(false);
        spiderWebs.SetActive(false);
    }

    public void StartMenuNewGame()
    {
        StartCoroutine(ButtonDemo("Starts a new game"));
    }
    public void StartMenuSettings()
    {
        StartCoroutine(ButtonDemo("Displays the Settings menu"));
    }
    public void StartMenuAbout()
    {
        StartCoroutine(ButtonDemo("Displays the About page"));
    }
    public void StartMenuQuit()
    {
        StartCoroutine(ButtonDemo("Quits the game"));
    }

    public void PauseMenuResume()
    {
        StartCoroutine(ButtonDemo("Resumes the game"));
    }
    public void PauseMenuSettings()
    {
        StartCoroutine(ButtonDemo("Displays the Settings menu"));
    }
    public void PauseMenuAbout()
    {
        StartCoroutine(ButtonDemo("Pauses the game"));
    }
    public void PauseMenuQuit()
    {
        StartCoroutine(ButtonDemo("Quits the game"));
    }
    public void SettingsMenuBack()
    {
        StartCoroutine(ButtonDemo("Returns to previous menu"));

    }
    public void AboutMenuBack()
    {
        StartCoroutine(ButtonDemo("Returns to previous menu"));
    }

    private IEnumerator ButtonDemo(string demoString)
    {
        buttonDemoText.text = demoString;
        yield return new WaitForSecondsRealtime(1f);
        buttonDemoText.text = "";
    }

}
