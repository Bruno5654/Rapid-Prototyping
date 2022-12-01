using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float time;
    private int score;
    private int intTime;
    
    public int enemyScore;
    public GameObject enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemySpawner, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        intTime = (int)time;
        score = intTime + enemyScore;
    }
}
