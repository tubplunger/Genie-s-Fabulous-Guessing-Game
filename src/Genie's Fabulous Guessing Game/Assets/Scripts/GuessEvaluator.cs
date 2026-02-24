using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessEvaluator : MonoBehaviour
{
    private int targetNumber;

    void Start()
    {
        GenerateNumber();
    }

    public void GenerateNumber()
    {
        targetNumber = Random.Range(1, 101); // 1-100
        Debug.Log("SECRET NUMBER (for testing): " + targetNumber);
    }

    // Returns the results of the guess
    public GuessResult EvaluateGuess(int guess)
    {
        if (guess == targetNumber)
        {
            return GuessResult.Correct;
        }
        else if (guess > targetNumber)
        {
            return GuessResult.TooHigh;
        }
        else
        {
            return GuessResult.TooLow;
        }
    }
}

public enum GuessResult
{
    TooLow,
    TooHigh,
    Correct
}