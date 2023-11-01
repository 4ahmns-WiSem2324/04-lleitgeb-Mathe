using UnityEngine;
using TMPro;
using System;

public class DeleteablePrime : MonoBehaviour
{
    public TMP_InputField inputText;
    public TextMeshProUGUI feedbackText;
    private int number;
    private bool isPrime;
    private int primeCounter;

    private void Start()
    {
        feedbackText.text = "Gib eine Primzahl ein";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && inputText.text != "")
        {
            try
            {
                CheckNumber();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }

    public void CheckNumber()
    {
        number = int.Parse(inputText.text);
        isPrime = IsPrime(number);

        if (!isPrime)
        {
            feedbackText.text = number + " ist keine Primzahl";
        }
        else
        {
            primeCounter++;
            UpdateCounter();
        }
    }

    private bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= Mathf.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }

    public void UpdateCounter()
    {
        string numStr = number.ToString();
        int length = numStr.Length;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (i == j)
                    continue;

                string subStr = numStr.Remove(j, 1);
                int subNum = int.Parse(subStr);

                if (IsPrime(subNum))
                    primeCounter++;
            }
        }

        feedbackText.text = "In der Nummer " + number + " gibt es " + primeCounter + " Primzahlen";
        primeCounter = 0;
    }
}