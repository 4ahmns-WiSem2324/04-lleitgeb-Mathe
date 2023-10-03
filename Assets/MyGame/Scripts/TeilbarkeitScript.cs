using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeilbarkeitScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI scoreText;
    private int numberToCheck;
    private int score = 0;
    private int roundsPlayed = 0;

    private void Start()
    {
        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        if (roundsPlayed >= 20)
        {
            EndGame();
            return;
        }

        numberToCheck = Random.Range(1, 101);
        numberText.text = "Durch welche Zahl ist " + numberToCheck + " teilbar?";
    }

    public void CheckDivisibility(int divisor)
    {
        if (roundsPlayed >= 20)
        {
            return;
        }

        if (numberToCheck % divisor == 0)
        {
            numberText.text = "Richtig! " + numberToCheck + " ist durch " + divisor + " teilbar.";
            score++;
            scoreText.text = score + "/20";
        }
        else
        {
            numberText.text = "Falsch! " + numberToCheck + " ist nicht durch " + divisor + " teilbar.";
            scoreText.text = score + "/20";
        }

        roundsPlayed++;

        if (roundsPlayed >= 20)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(GenerateNextNumberAfterDelay());
        }
    }

    private IEnumerator GenerateNextNumberAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        GenerateRandomNumber();
        scoreText.text = "";
    }

    private void EndGame()
    {
        numberText.text = "Geschafft!";
        scoreText.text = score + "/20";
        StartCoroutine(ReturnToStartSceneAfterDelay());
    }

    private IEnumerator ReturnToStartSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("StartScene");
    }
}