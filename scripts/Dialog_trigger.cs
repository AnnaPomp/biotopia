using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{
    //daca player ul vine catre npc se declanseaza dialogul
    public Dialog dialogScript;
    private bool playerDetected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag=="PERSONAJ")
        {
            playerDetected = true;
            dialogScript.ToggleIndicator(playerDetected);
            dialogScript.EndDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PERSONAJ")
        {
            playerDetected = false;
            dialogScript.ToggleIndicator(playerDetected);
        }
    }
    private void Update()
    {
     if(playerDetected&&Input.GetKeyDown(KeyCode.Q))
        {
            dialogScript.StartDialogue();
        }
    }
}
