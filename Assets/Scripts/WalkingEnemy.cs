using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
   [SerializeField] SpriteRenderer spriteRenderer;
   [SerializeField] Rigidbody2D rigidbody2D;
   [SerializeField] bool isFacingRight;
   [SerializeField] Transform groundCheckPos;
   [SerializeField] LayerMask collisionLayer;
   [SerializeField] Vector2 edgeCheckOffset;

    Vector2 edgeCheckPos;
    Vector2 edgeCheckSize;
    Vector2 groundCheckSize;
    bool edgeCheck;
    bool groundCheck;
    float direction;
    
    public float movementSpeed;
    public GameObject gm;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if(!isFacingRight)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        edgeCheckSize = new Vector2(0.5f, 0.5f);
        groundCheckSize = new Vector2(0.25f, 0.25f);
    }

    void Update()
    {
        edgeCheckPos = new Vector2(transform.position.x + (direction * edgeCheckOffset.x), transform.position.y - edgeCheckOffset.y);

        edgeCheck = Physics2D.OverlapBox(edgeCheckPos, edgeCheckSize, 0, collisionLayer);
        groundCheck = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, collisionLayer);

        if (!edgeCheck && !groundCheck)
        {
            ChangeDirection();
        }
    }
    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(direction * movementSpeed, rigidbody2D.velocity.y);
    }

    void ChangeDirection()
    {
        if(direction == 1)
        {
            direction = -1;
            spriteRenderer.flipX = true;
        }
        else
        {
            direction = 1;
            spriteRenderer.flipX = false;
        }
    }

    void OnDrawGizmos()
    {
        if(edgeCheck)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(edgeCheckPos, edgeCheckSize);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(edgeCheckPos, edgeCheckSize);
        }
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.GetComponent<HandleGame>().coins -= 3;
            //collision.transform.position = respawnPoint.position;
            collision.GetComponent<BasicCharacterController>().isDead = true;
        }
    }

}
