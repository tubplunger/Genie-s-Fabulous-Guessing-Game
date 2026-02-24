using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public TMP_InputField inputField;
    public GuessEvaluator evaluator;

    private int attempts = 0;
    private bool gameActive = true;

    void Start()
    {
        // Clear field at the start of the game
        inputField.text = "";

        Debug.Log("Game has started! Guess a number between 1 and 100.");

        // Listen for enter key submission
        inputField.onSubmit.AddListener(SubmitGuess);
    }

    public void SubmitGuess(string input)
    {
        if (!gameActive)
            return;

        int guess;

        // Validate number
        if (!int.TryParse(input, out guess))
        {
            Debug.Log("Please enter a valid number.");
            inputField.text = "";
            return;
        }

        attempts++;

        GuessResult result = evaluator.EvaluateGuess(guess);

        switch (result)
        {
            case GuessResult.TooLow:
                Debug.Log("Too low! Try again.");
                break;

            case GuessResult.TooHigh:
                Debug.Log("Too high! Try again.");
                break;

            case GuessResult.Correct:
                Debug.Log("Correct! You guessed it in " + attempts + " attempts!");
                break;
        }

        // Clear for the next guess
        inputField.text = "";
        inputField.ActivateInputField();
    }

    private void EndGame()
    {
        gameActive = false;
        inputField.interactable = false;
        Debug.Log("Game over. Input Disabled.");
    }
}
