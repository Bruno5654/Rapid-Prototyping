﻿using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BasicCharacterController : MonoBehaviour
{
    protected bool jumped;
    protected bool dashed;

    public float speed = 5.0f;
    public float jumpForce = 1000.0f;
    public float dashForce = 3.0f;
    public float dashTime = 0.5f;
    private bool canDash = false;
    private bool isDash = false;
    private CapsuleCollider2D cc2d;
    private Vector2 dirDash;
    private float horizInput = 0.0f;
    private bool isResPlayer;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;
    public bool isDead = false;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public TrailRenderer trailRenderer;
    public GameObject gm;
    public Transform respawnPoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isDead)
        {
            if (other.tag == "Coin")
            {
                gm.GetComponent<HandleGame>().coins++;
                Destroy(other.gameObject);
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(!isDead)
        {
            if (context.performed)
            {
                if (grounded == true)
                {
                    jumped = true;
                    Debug.Log("Should jump");
                }
            }

            if (jumped == true)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                Debug.Log("Jumping!");
                jumped = false;
            }
        }
    }

    public void callDash(InputAction.CallbackContext context)
    {
        if(!isDead)
        {
            if (canDash && !grounded)
            {
                canDash = false;
                isDash = true;
                trailRenderer.emitting = true;
                StartCoroutine(stopDash());
            }

            if (isDash)
            {
                dirDash = new Vector2(horizInput * speed * Time.fixedDeltaTime, 0.0f);
            }
        }
    }

    private IEnumerator stopDash()
    {
        yield return new WaitForSeconds(dashTime);
        isDash = false;
        trailRenderer.emitting = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        float inputVector = context.ReadValue<float>();
        horizInput = inputVector;
        animator.SetFloat("Speed", Mathf.Abs(horizInput));
    }

    void Update()
    {
        if (horizInput > 0.0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizInput < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        
        if(isDead)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        StartCoroutine(respawn());
        isResPlayer = true;
    }

   private IEnumerator respawn()
    {
        yield return new WaitForSeconds(1f);
        isDead = false;
        animator.SetBool("IsDead", false);
        if(isResPlayer)
        {
            transform.position = respawnPoint.position;
            isResPlayer = false;
        }

        

    }
    void FixedUpdate()
    {
        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);

        //Move Character
        if(!isDead)
        {
            if (!grounded && isDash) // If in the air and dashing.
            {
                rb.velocity = dirDash.normalized * dashForce;
                animator.SetBool("IsGrounded", false);
            }
            else if (!grounded) // If in the air less horizontal control.
            {
                rb.velocity = new Vector2((horizInput * speed * Time.fixedDeltaTime) / 2, rb.velocity.y);
                animator.SetBool("IsGrounded", false);
            }
            else
            {
                rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
                animator.SetBool("IsGrounded", true);
                canDash = true;
            }
        }
        
    }
}
