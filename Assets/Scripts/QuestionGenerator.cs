using System;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public static string GenerateQuestion(int numCount)
    {
        int[] numbers = new int[numCount];
        char[] operators = new char[numCount - 1];
        System.Random rand = new System.Random();

        for (int i = 0; i < numCount; i++)
        {
            numbers[i] = rand.Next(0, 10); 
        }

        string[] ops = { "+", "-" }; //añadir más operadores si es necesario
        for (int i = 0; i < operators.Length; i++)
        {
            operators[i] = ops[rand.Next(0, ops.Length)][0];
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
