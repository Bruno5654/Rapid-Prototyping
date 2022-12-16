using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float runningTime;
    private float timeForSpawn;
    private int skillBracket;
    public float endTime;
    GameObject enemy;
    GameObject asteroid;
   
    public int score;
    public int enemyScore;
    public GameObject enemyToSpawn;
    public GameObject asteroidToSpawn;
    public TMP_Text scoreText;

    public bool endGame = false;

    // Start is called before the first frame update
    void SpawnEnemy()
    {
        enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        enemy.GetComponent<RedPlagueMover>().maxXOffset = Random.Range(-9.0f, 9.0f);
        
    }

    void SpawnAstroid()
    {
        asteroid = Instantiate(asteroidToSpawn, transform.position, transform.rotation);
        asteroid.GetComponent<Asteroid>().maxXOffset = Random.Range(-9.0f, 9.0f);

    }

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime;
        timeForSpawn += Time.deltaTime;
        scoreText.text = score.ToString();
        
        if (endGame == false)
        {
            score = (int)runningTime + enemyScore;
        }

        if(score <= 40)
        {
            skillBracket = 5;
        }
        else if(score > 40 && score <= 75)
        {
            skillBracket = 4;
        }
        else if (score > 75 && score <= 150)
        {
            skillBracket = 3;
        }
        else
        {
            skillBracket = 2;
        }

        if (timeForSpawn >= skillBracket)
        {
            timeForSpawn = 0;
            int randNum = Random.Range(1, 6);
            switch(randNum)
            {
                case 1:
                    SpawnAstroid();
                    break;
                case 2:
                    SpawnAstroid();
                    SpawnAstroid();
                    break;
                case 3:
                    SpawnAstroid();
                    SpawnEnemy();
                    SpawnAstroid();
                    break;
                case 4:
                    SpawnAstroid();
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnAstroid();
                    break;
                case 5:
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    break;
                case 6:
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    SpawnEnemy();
                    break;

            }

            if(endGame)
            {
                SceneManager.LoadScene(0);
            }

        }
    }

    
}
