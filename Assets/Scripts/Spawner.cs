using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float increasingSpeed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    public void ChildDied()
    {
        Debug.Log("OH NO, Kid Died!");
        SpawnEnemy();
        increasingSpeed += 0.1f;
    }

    private void SpawnEnemy()
    {
        GameObject instantiatedEnemy = Instantiate(enemy, this.transform);
        instantiatedEnemy.GetComponent<Enemy>().startingSpeed += increasingSpeed;
    }
}
