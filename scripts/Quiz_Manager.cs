using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject quizWindow;
    public TMP_Text questionText;
    public TMP_Text feedbackText;
    public float waitTimeBeforeNext = 1f;

    private int correctAnswerIndex;

    void Start()
    {
        quizWindow.SetActive(false);  // Ascunde quiz-ul la început
    }

    public void ShowQuestion(string question, string[] answers, int correctIndex)
    {
        if (quizWindow == null || questionText == null || feedbackText == null)
        {
            Debug.LogError("❌ Verifică că toate referințele sunt setate corect în Inspector.");
            return;
        }

        quizWindow.SetActive(true);  // Arată quiz-ul
        questionText.text = question;  // Afișează întrebarea
        feedbackText.text = "";  // Resetează feedback-ul

        correctAnswerIndex = correctIndex;  // Setează răspunsul corect

        // Afișează răspunsurile
        for (int i = 0; i < answers.Length; i++)
        {
            feedbackText.text += $"{i + 1}. {answers[i]}\n";
        }
    }

    void Update()
    {
        if (quizWindow.activeSelf)  // Verifică dacă fereastra quiz-ului este activă
        {
            // Așteaptă apăsarea unei taste pentru a da răspuns
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CheckAnswer(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CheckAnswer(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CheckAnswer(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CheckAnswer(3);
            }
        }
    }

    private void CheckAnswer(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswerIndex)
        {
            feedbackText.text = "Corect!";
            feedbackText.color = Color.green;
            Debug.Log("✅ Răspuns corect!");
            StartCoroutine(CloseQuiz());
        }
        else
        {
            feedbackText.text = "Greșit! Încearcă din nou.";
            feedbackText.color = Color.red;
            Debug.Log("❌ Răspuns greșit!");
        }
    }

    IEnumerator CloseQuiz()
    {
        yield return new WaitForSeconds(waitTimeBeforeNext);  // Așteaptă înainte de a închide quiz-ul
        quizWindow.SetActive(false);  // Ascunde quiz-ul
    }
}
