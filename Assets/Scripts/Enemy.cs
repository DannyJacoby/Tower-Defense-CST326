using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    // public Path route;
    private Waypoint[] myRoute;
    private int index = 0;
    private Vector3 nextWaypoint;
    
    public int startingValue = 10;
    [HideInInspector]
    public int value;
    public float startingHealth = 100f;
    [HideInInspector]
    public float health;
    [Range (0f, 5f)] public float startingSpeed = 0.75f;
    [Range (0f, 5f)] public float speed;
    
    private Spawner m_Spawner;
    
    private UI m_UI;

    public UnityEvent DeathEvent;

    [Header("Unity Stuff, Don't Mess with")]
    public Image healthBar;
    
    void Awake()
    {
        myRoute = FindObjectOfType<Path>().GetComponentsInChildren<Waypoint>();
        transform.position = myRoute[index].transform.position;
        m_Spawner = GetComponentInParent<Spawner>();
        m_UI = GetComponentInParent<UI>();
        Recalculate();
    }
    void Start()
    {
        speed = startingSpeed;
        health = startingHealth;
        value = startingValue;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((transform.position - myRoute[index + 1].transform.position).magnitude < 0.1f)
        {
            index++;
            Recalculate();
        }

        Vector3 movementThisFrame = Time.deltaTime * speed * nextWaypoint;
        transform.Translate(movementThisFrame);
        
    }

    void Recalculate()
    {
        if (index + 1 >= myRoute.Length)
        {
            Die(health);
            return;
        }
        else
        {
            nextWaypoint = (myRoute[index + 1].transform.position - myRoute[index].transform.position).normalized;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // let me die when I get hit by something
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TakeDamage(20f);
        }
        
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startingHealth;
        
        if (health <= 0)
        {
            Die(0f);
        }
    }

    public void Die(float healthRemaining)
    {
        DeathEvent.Invoke();
        DeathEvent.RemoveAllListeners();
        m_UI.IncreasePurse( (health > 0) ? 0 : value );
        m_Spawner.ChildDied(healthRemaining);
        Destroy(gameObject);
    }

}
