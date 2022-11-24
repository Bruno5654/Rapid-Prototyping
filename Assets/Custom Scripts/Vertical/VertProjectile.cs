using UnityEngine;
using System.Collections;

public class VertProjectile : MonoBehaviour 
{
	public float speed;
	
	void Update () 
	{
		transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
	}
	
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<RedPlagueMover>().TakeDamage(30);
			Destroy(gameObject);
		}
	}
}
