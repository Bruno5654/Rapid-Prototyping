using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedPlagueMover : MonoBehaviour 
{
	public float vSpeed;
	public float maxXOffset;
	public float health;
	public Image HealthBar;
	public GameManager GameManager;
	protected float origXPos;
	
	void Start()
	{
		origXPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(origXPos + maxXOffset * Mathf.Sin(Time.time), transform.position.y);
		HealthBar.fillAmount = health / 100;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
            GameObject.Find("GameManager").GetComponent<GameManager>().endGame = true;
            Destroy (other.gameObject);
        }
	}

	public void TakeDamage(float damage)
    {
		health -= damage;
        if(health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().enemyScore += 3;
            Destroy(gameObject);
        }
    }

}
