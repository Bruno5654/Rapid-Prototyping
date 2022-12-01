using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;

    private float time = 0;
    private int spawned = 0;
    private int countToSpawn;

    void Start()
    {
        countToSpawn = Random.Range(1, 2);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time>spawnRate)
        {
            GameObject enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
            enemy.GetComponent<RedPlagueMover>().maxXOffset = Random.Range(-8.0f, 8.0f);


            time = 0;
            spawned++;
            if(spawned > countToSpawn)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
