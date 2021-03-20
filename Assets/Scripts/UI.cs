using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI purseValue;

    public int totalScore;
    public int totalPurse;

    void Start()
    {
        IncreasePurse(100);
    }
    
    public void IncreaseScore(int amount)
    {
        
    }

    public void IncreasePurse(int amount)
    {
        totalPurse += amount;
        purseValue.SetText("$" + totalPurse);
    }

}
