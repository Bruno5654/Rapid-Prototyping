using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float runningTime;
    private float timeForSpawn;
    GameObject enemy;
    public int score;
    

    public int enemyScore;
    public GameObject enemyToSpawn;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void SpawnEnemy()
    {
        enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        enemy.GetComponent<RedPlagueMover>().maxXOffset = Random.Range(-9.0f, 9.0f);
        
    }
   

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime;
        timeForSpawn += Time.deltaTime;
        score = (int)runningTime + enemyScore;
        scoreText.text = score.ToString();

        if(timeForSpawn >= 5)
        {
            timeForSpawn = 0;
            int randNum = Random.Range(1, 3);
            switch(randNum)
            {
                case 1:
                    SpawnEnemy();
                    break;
                case 2:
                    SpawnEnemy();
                    SpawnEnemy();
                    break;
                case 3:
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    break;
                case 4:
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    break;
            }
            
        }
    }

    
}
