using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score_script : MonoBehaviour
{
    public static int scoreVal = 0;
    Text score;
     void Start()
    {
        score = GetComponent<Text>(); 
    }
     void Update()
    {
        score.text = "Scor: " + scoreVal; 
    }
}
