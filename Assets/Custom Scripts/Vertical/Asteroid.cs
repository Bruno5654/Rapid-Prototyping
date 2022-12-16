using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float spinSpeed = 0.1f;
    public float maxXOffset;
    protected float origXPos;
   

  
    void Start()
    {
        origXPos = transform.position.x + maxXOffset;
        transform.position = new Vector2(origXPos, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().endGame = true;
            Destroy(other.gameObject);
        }
    }
}
