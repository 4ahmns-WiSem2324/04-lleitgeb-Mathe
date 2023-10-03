using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void LoadZahlenarten()
    {
        SceneManager.LoadScene("Zahlenarten");
    }

    public void LoadPrimzahlen()
    {
        SceneManager.LoadScene("Primzahlen");
    }

    public void LoadRechenarten()
    {
        SceneManager.LoadScene("EinfacheRechenarten");
    }

    public void LoadTeilbarkeitsregeln()
    {
        SceneManager.LoadScene("Teilbarkeitsregeln");
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartScene");
    }


}
