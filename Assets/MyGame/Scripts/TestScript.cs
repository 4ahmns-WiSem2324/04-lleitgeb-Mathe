using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    int x = 1234;


    void Start()
    {
        string y = x.ToString();
        y.Remove(2, 1);
        Debug.Log(int.Parse(y.Remove(2, 1)));

    }

    void Update()
    {
        
    }
}
