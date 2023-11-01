using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class SecondPrimzahlen : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    public TextMeshProUGUI scoreText;
    public TMP_InputField inputField;

    private int randomNumber;
    private bool isPrime;
    private int rounds = 0;
    private int score = 0;

    private void Start()
    {
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }



    private void OnInputFieldValueChanged(string newValue)
    {
        int number;
        if (int.TryParse(newValue, out number))
        {
            bool isPrime = IsPrime(number);

            if (isPrime)
            {
                answerText.text = number + " ist eine Primzahl.";
            }
            else
            {
                answerText.text = number + " ist keine Primzahl.";
            }
        }
    
    }

    bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        if (number <= 3)
        {
            return true;
        }

        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
}
