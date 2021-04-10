using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    public List<Defenses> myEmptyDefenses;
    public List<Defenses> myPlacedDefenses;

    public GameObject emptyDefense;
    public GameObject presetDefense1;

    public UI uiManager;
    // Start is called before the first frame update
    void Awake()
    {
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Collect()
    {
        myEmptyDefenses = new List<Defenses>();
        myPlacedDefenses = new List<Defenses>();
        
        Defenses[] allDefenses = gameObject.GetComponentsInChildren<Defenses>();
        foreach (var def in allDefenses)
        {
            if (def.isEmpty == true)
            {
                myEmptyDefenses.Add(def);
            }
            else
            {
                myPlacedDefenses.Add(def);
            }
        }
    }

    public void PlaceDefense(GameObject defenseSpot, Transform myTransform)
    {
        if (uiManager.totalPurse > 0 && uiManager.totalPurse - presetDefense1.GetComponent<Defenses>().price >= 0 && defenseSpot.GetComponent<Defenses>().isEmpty)
        {
            uiManager.DecreasePurse(presetDefense1.GetComponent<Defenses>().price);
            var instantiatedDefense = Instantiate(presetDefense1, myTransform.position, myTransform.rotation * Quaternion.Euler(0f,0f,0f));
            instantiatedDefense.transform.parent = this.gameObject.transform;
            Destroy(defenseSpot);
            Collect();
        }
        else if (!defenseSpot.GetComponent<Defenses>().isEmpty)
        {
            Debug.Log("Removing Placed Defense and Refunding");
            uiManager.IncreasePurse(presetDefense1.GetComponent<Defenses>().price);
            var instantiatedDefense = Instantiate(emptyDefense, myTransform.position, myTransform.rotation * Quaternion.Euler(0f,0f,0f));
            instantiatedDefense.transform.parent = this.gameObject.transform;
            Destroy(defenseSpot);
            Collect();
        }
        else
        {
            Debug.Log("YOU'RE BROKE");
        }
    }
}
