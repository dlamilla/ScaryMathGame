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

    public QuestionGenerator questionGenerator;
    private Difficulty currentDifficulty;

    private string currentQuestion;
    private int currentAnswer;

    public void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficulty(Difficulty.Easy));
        mediumButton.onClick.AddListener(() => SetDifficulty(Difficulty.Medium));
        hardButton.onClick.AddListener(() => SetDifficulty(Difficulty.Hard));
        checkButton.onClick.AddListener(CheckAnswer);

        questionText.text = "";
        feedbackText.text = "Selecciona una dificultad para comenzar.";
    }

    private void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;
        GenerateNewQuestion();
    }

    private void GenerateNewQuestion()
    {
        currentQuestion = questionGenerator.GenerateQuestion(currentDifficulty);
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
