using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public string levelToLoad = "MainMenuRestart";
    
    public GameObject enemy;
    public float increasingSpeed = 0f;

    public GoalTower endGoal;

    private AudioSource m_AudioSource;
    public AudioClip explosionSound;

    private int m_TotalDestroyedEnemies = 0;
    public int goalLimiter = 10;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        SpawnEnemy();
    }

    public void ChildDied(float amount)
    {
        PlaySound(explosionSound);
        Debug.Log("OH NO, Kid Died!");
        if (amount > 0)
        {
            Debug.Log("But it did hurt the tower for " + amount + " damage");
            endGoal.TakeDamage(amount);
        }
        SpawnEnemy();
        increasingSpeed += 0.1f;
    }

    private void SpawnEnemy()
    {
        if (m_TotalDestroyedEnemies <= goalLimiter)
        {
            GameObject instantiatedEnemy = Instantiate(enemy, this.transform);
            instantiatedEnemy.GetComponent<Enemy>().startingSpeed += increasingSpeed;
            m_TotalDestroyedEnemies++;
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    
    private void PlaySound(AudioClip audioClip)
    {
        Debug.Log("Made Death Sounds");
        m_AudioSource.clip = audioClip;
        m_AudioSource.Play();
    }
    
}
