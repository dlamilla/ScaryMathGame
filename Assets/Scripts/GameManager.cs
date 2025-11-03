using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text feedbackText;

    [Header("Difficulty Settings")]
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button checkButton;

    private string currentQuestion;
    private int currentAnswer;
    private int numCount = 2;

    public void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficulty(2));
        mediumButton.onClick.AddListener(() => SetDifficulty(3));
        hardButton.onClick.AddListener(() => SetDifficulty(4));
        checkButton.onClick.AddListener(CheckAnswer);

        questionText.text = "";
        feedbackText.text = "Selecciona una dificultad para comenzar.";
    }

    private void SetDifficulty(int count)
    {
        numCount = count;
        GenerateNewQuestion();
    }

    private void GenerateNewQuestion()
    {
        currentQuestion = QuestionGenerator.GenerateQuestion(numCount);
        currentAnswer = QuestionGenerator.Evaluate(currentQuestion);
        questionText.text = currentQuestion;
        answerInput.text = "";
        feedbackText.text = "Resuelve la operación.";
    }

    private void CheckAnswer()
    {
        if (int.TryParse(answerInput.text, out int playerAnswer))
        {
            if (playerAnswer == currentAnswer)
            {
                feedbackText.text = "¡Correcto! Generando nueva pregunta...";
                GenerateNewQuestion();
            }
            else
            {
                feedbackText.text = "Incorrecto. Intenta de nuevo.";
            }
        }
        else
        {
            feedbackText.text = "Por favor, ingresa un número válido.";
        }
    }
}
