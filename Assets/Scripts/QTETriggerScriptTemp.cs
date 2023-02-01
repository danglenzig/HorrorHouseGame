using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class QTETriggerScriptTemp : MonoBehaviour
{
    private Keyboard myKB;
    [SerializeField] private string lookForTag = "Player";
    public string QTEPromptString = "Press enter to magic the door open.";
    [SerializeField] private TMP_Text QTEPromptText;
    [SerializeField] private GameObject QTEObject;

    private bool QTESolved = false;
    private bool QTEPromptUp = false;
    private bool QTEInProgress = false;


    private void Awake()
    {
        myKB = Keyboard.current;

    }

    // Start is called before the first frame update



    void Start()
    {
        QTEObject.SetActive(false);
        QTEPromptText.text = QTEPromptString;
        QTEPromptText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (QTESolved)
        {
            gameObject.SetActive(false);
        }
        if (QTEPromptUp)
        {
            
            if (myKB.enterKey.wasPressedThisFrame)
            {
                QTEPromptText.gameObject.SetActive(false);
                QTEPromptUp = false;

                QTEInProgress = true;
                QTEObject.SetActive(true);

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ghost")
        {
            if (!QTEInProgress)
            {
                QTEPromptText.gameObject.SetActive(true);
                QTEPromptUp = true;
            }
            
        }
    }

    


    public void QTEWin()
    {
        QTEPromptText.text = "Sucess!!!";
        QTEPromptText.gameObject.SetActive(true);
        QTEObject.SetActive(false);
        StartCoroutine(KillQTE());
    }

    public void QTEFail()
    {
        QTEObject.SetActive(false);
        QTEInProgress=false;
    }

    private IEnumerator KillQTE()
    {
        yield return new WaitForSecondsRealtime(1);
        QTEPromptText.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }








}
