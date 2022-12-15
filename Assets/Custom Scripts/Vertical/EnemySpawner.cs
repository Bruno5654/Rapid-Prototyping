using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;

    private int spawned = 0;
    private int countToSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        
        
        spawned++;
        if (spawned > countToSpawn)
        {
            Destroy(gameObject);
        }
    }
}
