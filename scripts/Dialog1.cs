using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog1 : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text dialogTxt;
    public List<string> dialog;
    public float writingspeed;
    //nr dialog
    private int index;
    //pointer 
    private int CharIndex;
    private bool started = false;
    private bool waitfrnext = false;


    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
    //Start Dialog
    public void StartDialogue()
    {
        if (started)
        {
            return;
        }
        started = true;
        ToggleWindow(true);
        ToggleIndicator(false);
        //incepe cu prima linie de dialog
        GetDialogue(0);

    }
    private void GetDialogue(int i)
    {
        index = i;
        CharIndex = 0;
        dialogTxt.text = string.Empty;
        StartCoroutine(writing());
    }
    //End Dialog
    public void EndDialogue()
    {
        started = false;
        waitfrnext = false;
        StopAllCoroutines();
        ToggleWindow(false);

    }

    //writing logic
    IEnumerator writing()
    {
        yield return new WaitForSeconds(writingspeed);

        string currentDialogue = dialog[index];
        dialogTxt.text += currentDialogue[CharIndex];
        CharIndex++;
        if (CharIndex < currentDialogue.Length)
        {
            yield return new WaitForSeconds(writingspeed);
            StartCoroutine(writing());
        }
        else
        {
            waitfrnext = true;
        }


    }
    private void Update()
    {
        if (!started) return;
        if (waitfrnext == true && Input.GetKeyDown(KeyCode.Q))
        {
            waitfrnext = false;
            index++;
            if (index < dialog.Count)
            {
                GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }


        }
    }

}
