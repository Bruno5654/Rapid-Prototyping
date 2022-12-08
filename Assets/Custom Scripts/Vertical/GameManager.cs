using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float time;
    public int score;
    
    public int enemyScore;
    public GameObject enemySpawner;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemySpawner, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        score = (int)time + enemyScore;
        scoreText.text = score.ToString();
    }


}
