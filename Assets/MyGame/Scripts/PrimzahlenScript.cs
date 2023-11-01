using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class PrimzahlenScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI scoreText;
    public Button yesButton;
    public Button noButton;
    private int randomNumber;
    private bool isPrime;
    private int rounds = 0;
    private int score = 0;


    private void Start()
    {
        yesButton.onClick.AddListener(CheckIsPrime);
        noButton.onClick.AddListener(CheckIsNotPrime);

        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        if (rounds < 20)
        {
            rounds++;
            randomNumber = UnityEngine.Random.Range(1, 101);
            isPrime = IsPrime(randomNumber);

            numberText.text = "Ist " + randomNumber + " eine Primzahl?";
        }
        else
        {
            EndGame();
        }
    }

    private void CheckIsPrime()
    {
        if (isPrime)
        {
            score++;
            scoreText.text = score + "/20";
            numberText.text = "Richtig! " + randomNumber + " ist eine Primzahl.";
        }
        else
        {
            scoreText.text = score + "/20";
            numberText.text = "Falsch! " + randomNumber + " ist keine Primzahl.";
        }

        StartCoroutine(ShowNextNumberAfterDelay(3f));
    }

    private void CheckIsNotPrime()
    {
        if (!isPrime)
        {
            score++;
            scoreText.text = score + "/20";
            numberText.text = "Richtig! " + randomNumber + " ist keine Primzahl.";
        }
        else
        {
            scoreText.text = score + "/20";
            numberText.text = "Falsch! " + randomNumber + " ist eine Primzahl.";
        }

        StartCoroutine(ShowNextNumberAfterDelay(3f));
    }

    private void EndGame()
    {
        numberText.text = "Geschafft!";
        scoreText.text = score + "/20";
        StartCoroutine(ChangeSceneAfterDelay(3f));
    }

    private IEnumerator ChangeSceneAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("StartScene");
    }

    private bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator ShowNextNumberAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        GenerateRandomNumber();
    }

}