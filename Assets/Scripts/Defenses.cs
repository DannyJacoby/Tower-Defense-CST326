using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenses : MonoBehaviour
{
    public bool isEmpty;
    public Transform myTransform;

    public DefenseManager DM;

    public int price;
    
    void Awake()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }

    void Start()
    {
        DM = gameObject.GetComponentInParent<DefenseManager>();
    }
    
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            DM.PlaceDefense(this.gameObject, myTransform);
        }
    }
    
    
}


