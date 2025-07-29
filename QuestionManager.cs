using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    [Header("Main Form Inputs")]
    public TMP_InputField questionInput;
    public TMP_InputField answer1Input, answer2Input, answer3Input, answer4Input;
    public TMP_Dropdown correctAnswerDropdown;
    public TMP_InputField testIDInput;
    public Button saveButton, resetButton;
    public TMP_Text feedbackText;  

    [Header("Edit Popup")]
    public GameObject editPopupPanel;
    public TMP_InputField edit_questionInput;
    public TMP_InputField edit_answer1Input, edit_answer2Input, edit_answer3Input, edit_answer4Input;
    public TMP_Dropdown edit_correctAnswerDropdown;
    public TMP_InputField edit_testIDInput;
    public Button saveEditButton, cancelEditButton;
    public TMP_Text editFeedbackText; 

    [Header("Questions List UI")]
    public Transform questionsContentParent; // Content container din ScrollView (setat în Inspector)
    public GameObject questionItemPrefab;    // Prefab pentru un item listă (setat în Inspector)

    private int currentEditQuestionID = -1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        saveButton.onClick.AddListener(OnMainFormSave);
        resetButton.onClick.AddListener(ResetMainForm);

        saveEditButton.onClick.AddListener(OnEditPopupSave);
        cancelEditButton.onClick.AddListener(() => {
            editPopupPanel.SetActive(false);
            ClearEditPopup();
        });

        editPopupPanel.SetActive(false);

        StartCoroutine(LoadQuestionsAndDisplay());
    }

    IEnumerator LoadQuestionsAndDisplay()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/get_questions.php");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            feedbackText.text = "Eroare la încărcare: " + www.error;
            yield break;
        }

        string wrappedJson = "{\"questions\":" + www.downloadHandler.text + "}";
        var data = JsonUtility.FromJson<QuestionListWrapper>(wrappedJson);

        Debug.Log($"Am încărcat {data.questions.Count} întrebări.");  // Debug

        DisplayQuestions(data.questions);
    }

    void DisplayQuestions(List<QuestionData> questions)
    {
        foreach (Transform child in questionsContentParent)
            Destroy(child.gameObject);

        foreach (var q in questions)
        {
            GameObject itemGO = Instantiate(questionItemPrefab, questionsContentParent);
            QuestionItemUI itemUI = itemGO.GetComponent<QuestionItemUI>();

            if (itemUI == null)
            {
                Debug.LogError("Prefab-ul questionItemPrefab NU are componenta QuestionItemUI!");
                return;
            }

            itemUI.Setup(q);
        }
    }

    // --- MAIN FORM ---

    void OnMainFormSave()
    {
        if (string.IsNullOrWhiteSpace(questionInput.text))
        {
            feedbackText.text = "Întrebarea este obligatorie.";
            return;
        }

        StartCoroutine(SaveQuestion(false));
    }

    void ResetMainForm()
    {
        currentEditQuestionID = -1;
        questionInput.text = "";
        answer1Input.text = "";
        answer2Input.text = "";
        answer3Input.text = "";
        answer4Input.text = "";
        correctAnswerDropdown.value = 0;
        testIDInput.text = "";
        feedbackText.text = "";
    }

    // --- EDIT POPUP ---

    public void OpenEditPopup(QuestionData q)
    {
        currentEditQuestionID = q.id;

        edit_questionInput.text = q.question_text;
        edit_answer1Input.text = q.answer_1;
        edit_answer2Input.text = q.answer_2;
        edit_answer3Input.text = q.answer_3;
        edit_answer4Input.text = q.answer_4;
        edit_correctAnswerDropdown.value = q.correct_answer - 1;
        edit_testIDInput.text = q.test_id.ToString();
        editFeedbackText.text = $"Editare întrebare ID {q.id}";

        Debug.Log($"Deschid popup edit pentru ID {q.id} cu întrebarea: {q.question_text}");  // Debug

        editPopupPanel.SetActive(true);
    }

    void ClearEditPopup()
    {
        currentEditQuestionID = -1;
        edit_questionInput.text = "";
        edit_answer1Input.text = "";
        edit_answer2Input.text = "";
        edit_answer3Input.text = "";
        edit_answer4Input.text = "";
        edit_correctAnswerDropdown.value = 0;
        edit_testIDInput.text = "";
        editFeedbackText.text = "";
    }

    void OnEditPopupSave()
    {
        if (string.IsNullOrWhiteSpace(edit_questionInput.text))
        {
            editFeedbackText.text = "Întrebarea este obligatorie.";
            return;
        }

        StartCoroutine(SaveQuestion(true));
    }

    // --- SAVE (add/update) ---

    IEnumerator SaveQuestion(bool fromEditPopup)
    {
        WWWForm form = new WWWForm();

        if (fromEditPopup)
        {
            form.AddField("question_text", edit_questionInput.text);
            form.AddField("answer_1", edit_answer1Input.text);
            form.AddField("answer_2", edit_answer2Input.text);
            form.AddField("answer_3", edit_answer3Input.text);
            form.AddField("answer_4", edit_answer4Input.text);
            form.AddField("correct_answer", edit_correctAnswerDropdown.value + 1);
            form.AddField("test_id", edit_testIDInput.text);
        }
        else
        {
            form.AddField("question_text", questionInput.text);
            form.AddField("answer_1", answer1Input.text);
            form.AddField("answer_2", answer2Input.text);
            form.AddField("answer_3", answer3Input.text);
            form.AddField("answer_4", answer4Input.text);
            form.AddField("correct_answer", correctAnswerDropdown.value + 1);
            form.AddField("test_id", testIDInput.text);
        }

        if (currentEditQuestionID == -1)
        {
            UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/add_question.php", form);
            yield return www.SendWebRequest();

            string msg = www.result == UnityWebRequest.Result.Success ? "Întrebare adăugată!" : "Eroare la adăugare: " + www.error;

            if (fromEditPopup)
                editFeedbackText.text = msg;
            else
                feedbackText.text = msg;
        }
        else
        {
            form.AddField("id", currentEditQuestionID);
            UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/update_question.php", form);
            yield return www.SendWebRequest();

            string msg = www.result == UnityWebRequest.Result.Success ? "Întrebare actualizată!" : "Eroare la actualizare: " + www.error;

            if (fromEditPopup)
                editFeedbackText.text = msg;
            else
                feedbackText.text = msg;
        }

        if (fromEditPopup)
        {
            if (!editFeedbackText.text.Contains("Eroare"))
            {
                ClearEditPopup();
                editPopupPanel.SetActive(false);
            }
        }
        else
        {
            if (!feedbackText.text.Contains("Eroare"))
                ResetMainForm();
        }

        // reload list
        yield return LoadQuestionsAndDisplay();
    }

    // --- DELETE ---

    public void DeleteQuestionByID(int id)
    {
        StartCoroutine(DeleteRoutine(id));
    }

    IEnumerator DeleteRoutine(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/delete_question.php", form);
        yield return www.SendWebRequest();

        feedbackText.text = www.result == UnityWebRequest.Result.Success
            ? "Șters cu succes!"
            : "Eroare la ștergere: " + www.error;

        if (www.result == UnityWebRequest.Result.Success)
            yield return LoadQuestionsAndDisplay();
    }
}
