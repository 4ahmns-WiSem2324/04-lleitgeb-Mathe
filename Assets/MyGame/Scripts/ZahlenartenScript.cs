using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZahlenartenScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI scoreText;
    public Toggle naturalNumberToggle;
    public Toggle wholeNumberToggle;
    public Toggle rationalNumberToggle;
    public Button nextButton;
    private float currentNumber;
    private NumberType correctType;
    private int score;
    private int rounds;
    private bool selectionMade = false;

    enum NumberType
    {
        NaturalNumber,
        WholeNumber,
        RationalNumber
    }

    private void Start()
    {
        nextButton.onClick.AddListener(NextButtonClick);
        GenerateRandomNumber();
        score = 0;
        rounds = 0;
    }

    private void GenerateRandomNumber()
    {
        correctType = (NumberType)Random.Range(0, 3);

        switch (correctType)
        {
            case NumberType.NaturalNumber:
                currentNumber = Random.Range(1, 101);
                break;
            case NumberType.WholeNumber:
                currentNumber = Random.Range(-101, 101);
                break;
            case NumberType.RationalNumber:
                int zaehler = Random.Range(1, 101);
                int nenner = Random.Range(1, 2);
                currentNumber = (float)zaehler / nenner;
                break;
        }

        numberText.text = "Ist " + currentNumber + " eine...";
        naturalNumberToggle.isOn = false;
        wholeNumberToggle.isOn = false;
        rationalNumberToggle.isOn = false;
        selectionMade = false;
        nextButton.interactable = false;
    }

    public void HandleToggleChange()
    {
        selectionMade = true;
        nextButton.interactable = true;
    }

    public void NextButtonClick()
    {
        if (selectionMade)
        {
            NumberType selectedType = NumberType.NaturalNumber;

            if (naturalNumberToggle.isOn)
            {
                selectedType = NumberType.NaturalNumber;
            }
            else if (wholeNumberToggle.isOn)
            {
                selectedType = NumberType.WholeNumber;
            }
            else if (rationalNumberToggle.isOn)
            {
                selectedType = NumberType.RationalNumber;
            }

            if (selectedType == correctType)
            {
                score++;
                numberText.text = "Richtig!";
                scoreText.text = score + "/20";
            }
            else
            {
                numberText.text = "Falsch!";
                scoreText.text = score + "/20";
            }

            rounds++;

            if (rounds == 20)
            {
                EndGame();
            }
            else
            {
                StartCoroutine(GenerateNextNumberAfterDelay());
            }
        }
    }

    private IEnumerator GenerateNextNumberAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        GenerateRandomNumber();
    }

    private void EndGame()
    {
        StopAllCoroutines();
        numberText.text = "Spiel beendet!";
        scoreText.text = score + "/20";
        naturalNumberToggle.interactable = false;
        wholeNumberToggle.interactable = false;
        rationalNumberToggle.interactable = false;
        nextButton.interactable = false;
        StartCoroutine(ChangeSceneAfterDelay(3f));
    }

    private IEnumerator ChangeSceneAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("StartScene");
    }
}