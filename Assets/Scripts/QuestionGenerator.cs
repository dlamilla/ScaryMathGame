using System;
using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class QuestionGenerator : MonoBehaviour
{
    [Header("Custom values")]
    public int[] customNumbers;
    public string[] customOperators;

    public Difficulty currentDifficult = Difficulty.Easy;

    public void Start()
    {
        GenerateQuestion(currentDifficult);
    }

    public string GenerateQuestion(Difficulty difficulty)
    {
        int numCount = difficulty == Difficulty.Easy ? 2 : difficulty == Difficulty.Medium ? 3 : 4;

        int[] numbers = new int[numCount];
        string[] operators = new string[numCount - 1];

        for (int i = 0; i < numCount; i++)
        {
            numbers[i] = customNumbers[UnityEngine.Random.Range(0,customNumbers.Length)];
        }

        string[] ops = customOperators;
        for (int i = 0; i < operators.Length; i++)
        {
            operators[i] = ops[UnityEngine.Random.Range(0, customOperators.Length)];
        }

        string question = "";
        for (int i = 0; i < numCount; i++)
        {
            question += numbers[i];
            if(i < operators.Length)
            {
                question += " " + operators[i] + " ";
            }
        }

        return question;
    }

    public static int Evaluate(string expression)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        return Convert.ToInt32(dt.Compute(expression, ""));
    }
}
