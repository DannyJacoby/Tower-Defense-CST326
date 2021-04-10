using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI purseValue;
    
    public int totalPurse;

    void Start()
    {
        IncreasePurse(100);
    }
    
    public void IncreasePurse(int amount)
    {
        totalPurse += amount;
        purseValue.SetText("$" + totalPurse);
    }

    public void DecreasePurse(int amount)
    {
        totalPurse -= amount;
        purseValue.SetText("$" + totalPurse);
    }

    void StartGame()
    {
        
    }

    void RestartGame()
    {
        
    }

}
