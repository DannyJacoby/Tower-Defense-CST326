using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalTower : MonoBehaviour
{
    
    [Header("Unity Stuff, Don't Mess with")]
    public Image healthBar;
    public float startingHealth = 100f;
    public float health;
    public string levelToLoad = "MainMenuRestart";
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startingHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
}
