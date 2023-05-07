using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyType;
    public GameObject playerCharacter;
    public int enemyCount;
    
    private float timer;
    private float spawnCountdown;
    private float enemySpeed;
    private int difficulty;

    private void Start()
    {
        timer = 0;
        difficulty = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        int timerSeconds = (int)(timer % 60);

        //Handle Ramping difficulty
       
        if(timerSeconds < 20)
        {
            difficulty = 0;
        }
        else if (timerSeconds > 20 && timerSeconds < 60)
        {
            difficulty = 1;
        }
        else if (timerSeconds > 60 && timerSeconds < 120)
        {
            difficulty = 2;
        }
        else
        {
            difficulty = 3;
        }

        enemySpeed = 20 * (difficulty + 1);

        //Spawn enemies
        
        if(Time.timeSinceLevelLoad > spawnCountdown)
        {
            spawnCountdown += 5 - difficulty;
            SpawnNewSlime();
        }

    }
    private void SpawnNewSlime()
    {
        Vector3 spawnPoint;
        spawnPoint.x = Random.Range(-10, 8);
        spawnPoint.y = Random.Range(-16, 2);
        spawnPoint.z = 0;
        GameObject spawnedEnemy = Instantiate(enemyType, spawnPoint, gameObject.transform.rotation);
        enemyCount += 1;
        spawnedEnemy.GetComponent<EnemySlime>().manager = gameObject;
        spawnedEnemy.GetComponent<EnemySlime>().player = playerCharacter;
        spawnedEnemy.GetComponent<EnemySlime>().speed = enemySpeed;
        spawnedEnemy.GetComponent<EnemySlime>().hp = 2 + difficulty;
        spawnedEnemy.SetActive(true);
    }

    
}
