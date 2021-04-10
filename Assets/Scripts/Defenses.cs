using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenses : MonoBehaviour
{
    public bool isEmpty;
    public Transform myTransform;

    public DefenseManager DM;

    public int price;

    public float hitAmount = 2f;

    public List<Enemy> currentEnemies;
    public Enemy currentTarget;

    private LineRenderer laser;
    public Transform turret;
    
    void Awake()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }

    void Start()
    {
        DM = gameObject.GetComponentInParent<DefenseManager>();
        if (!isEmpty)
        {
            laser = GetComponent<LineRenderer>();
            laser.SetPosition(0, turret.transform.position);
            laser.enabled = false;
        }
    }

    void Update()
    {
        if (currentTarget)
        {
            currentTarget.TakeDamage(hitAmount * Time.deltaTime);
            try
            {
                laser.SetPosition(1,currentTarget.transform.position);
            }
            catch (NullReferenceException)
            {
                laser.SetPosition(1, turret.transform.position);
            }
            laser.enabled = true;
        }
        else if(!currentTarget && !isEmpty)
        {
            laser.enabled = false;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Enemy newEnemy = other.GetComponent<Enemy>();
            newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy); });
            currentEnemies.Add(newEnemy);
            if (currentTarget == null) currentTarget = newEnemy;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Enemy oldEnemy = other.GetComponent<Enemy>();
            BookKeeping(oldEnemy);
        }
    }

    void BookKeeping(Enemy enemy)
    {
        currentEnemies.Remove(enemy);
        currentTarget = (currentEnemies.Count > 0) ? currentEnemies[0] : null;
    }
    
}


