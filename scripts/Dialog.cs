using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text dialogTxt;
    public List<string> dialog;
    public float writingspeed;

    private int index;
    private int CharIndex;
    private bool started = false;
    private bool waitfrnext = false;
    private bool readyToMove = false;
    private bool moveCharacter = false;

    public Transform character; // Personajul care trebuie să se miște
    public Transform targetPoint; // Destinația
    public float moveSpeed = 3f; // Viteza de deplasare

    // Adăugăm întrebarea și opțiunile
    public GameObject questionWindow; // Fereastra cu întrebare
    public TMP_Text questionText; // Textul întrebării
    public TMP_Text[] answerTexts; // Opțiunile răspuns
    private string correctAnswer = "B"; // Răspunsul corect
    private bool waitingForAnswer = false; // Așteaptă răspunsul jucătorului

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
        questionWindow.SetActive(false); // Ascunde fereastra cu întrebare
    }

    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    public void StartDialogue()
    {
        if (started)
        {
            return;
        }
        started = true;
        ToggleWindow(true);
        ToggleIndicator(false);
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        index = i;
        CharIndex = 0;
        dialogTxt.text = string.Empty;
        StartCoroutine(writing());
    }

    public void EndDialogue()
    {
        started = false;
        waitfrnext = false;
        StopAllCoroutines();
        ToggleWindow(false);

        // După finalizarea dialogului, arată întrebarea
        readyToMove = true;
        ToggleIndicator(true);
        questionWindow.SetActive(true); // Afișează întrebarea
        questionText.text = "Care este capitala Franței?"; // Exemplu de întrebare
        answerTexts[0].text = "A. Londra";
        answerTexts[1].text = "B. Paris";
        answerTexts[2].text = "C. Roma";
        waitingForAnswer = true;
    }

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
        if (!started)
        {
            // Dacă dialogul s-a terminat și jucătorul apasă Q, începe mișcarea
            if (readyToMove && Input.GetKeyDown(KeyCode.Q))
            {
                moveCharacter = true;
                readyToMove = false;  // Dezactivează indicatorul
                ToggleIndicator(false);
            }

            // Așteaptă răspunsul jucătorului la întrebare
            if (waitingForAnswer)
            {
                if (Input.GetKeyDown(KeyCode.A)) // Apăsarea tastelor A, B, C pentru răspuns
                {
                    CheckAnswer("A");
                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    CheckAnswer("B");
                }
                else if (Input.GetKeyDown(KeyCode.C))
                {
                    CheckAnswer("C");
                }
            }
            return;
        }

        if (waitfrnext && Input.GetKeyDown(KeyCode.Q))
        {
            waitfrnext = false;
            index++;
            if (index < dialog.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }

        // Mișcare personaj spre destinație
        if (moveCharacter)
        {
            float step = moveSpeed * Time.deltaTime;
            character.position = Vector3.MoveTowards(character.position, targetPoint.position, step);

            if (Vector3.Distance(character.position, targetPoint.position) < 0.1f)
            {
                moveCharacter = false; // Oprește mișcarea la destinație
            }
        }
    }

    // Verifică dacă răspunsul este corect
    void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            questionText.text = "Răspuns corect!"; // Răspuns corect
            questionWindow.SetActive(false);

            // Distruge obiectul personajului după răspunsul corect
            Destroy(character.gameObject); // Distruge obiectul personajului

            ToggleIndicator(true); // Arată indicatorul
            moveCharacter = true; // Permite mișcarea personajului
        }
        else
        {
            questionText.text = "Greșit! Încearcă din nou."; // Răspuns greșit
        }

        waitingForAnswer = false; // Oprește așteptarea răspunsului
    }
}
