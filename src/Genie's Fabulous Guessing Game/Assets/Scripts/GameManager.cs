using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public TMP_InputField inputField;
    public TMP_Text messageText;
    public TMP_Text attemptsText;
    public Button actionButton;
    public TMP_Text buttonText;
    public GuessEvaluator evaluator;

    private int attempts = 0;
    private bool gameActive = true;

    void Start()
    {
        inputField.onSubmit.AddListener(delegate { SubmitGuess(); });
        actionButton.onClick.AddListener(OnButtonPressed);

        StartGame();
    }

    void StartGame()
    {
        attempts = 0;
        gameActive = true;

        evaluator.GenerateNumber();

        inputField.text = "";
        inputField.interactable = true;
        inputField.ActivateInputField();

        messageText.text = "Game Started! Guess a number between 1 and 100.";
        attemptsText.text = "Attempts: 0";

        buttonText.text = "Waiting...";
        actionButton.interactable = false;
    }

    public void SubmitGuess()
    {
        if (!gameActive)
            return;

        int guess;

        if (!int.TryParse(inputField.text, out guess))
        {
            messageText.text = "Please enter a valid number.";
            inputField.text = "";
            return;
        }

        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        GuessResult result = evaluator.EvaluateGuess(guess);

        switch (result)
        {
            case GuessResult.TooLow:
                messageText.text = "Too low! Try again.";
                break;

            case GuessResult.TooHigh:
                messageText.text = "Too high! Try again.";
                break;

            case GuessResult.Correct:
                messageText.text = "Correct! You guessed it in " + attempts + " attempts!";
                EndGame();
                break;
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }

    void EndGame()
    {
        gameActive = false;

        inputField.interactable = false;

        buttonText.text = "Play Again";
        actionButton.interactable = true;
    }

    void OnButtonPressed()
    {
        if (!gameActive)
        {
            StartGame();
        }
    }
}