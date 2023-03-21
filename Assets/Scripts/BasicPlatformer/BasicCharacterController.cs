using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

//--------------------------------------------
/*Basic Character Controller Includes:  
    - Basic Jumping
    - Basic grounding with line traces
    - Basic horizontal movement
 */
//--------------------------------------------

public class BasicCharacterController : MonoBehaviour
{
    protected bool jumped;
    protected bool dashed;

    public float speed = 5.0f;
    public float jumpForce = 1000.0f;
   

    private float jumpPower = 0.0f;
    private float horizInput = 0.0f;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if(context.performed)
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

    public void Move(InputAction.CallbackContext context)
    {
        float inputVector = context.ReadValue<float>();
        horizInput = inputVector;
        animator.SetFloat("Speed", Mathf.Abs(horizInput));

    }

    void Update()
    {
        if(horizInput > 0.0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizInput < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);

        //Move Character
        if (grounded == false) // If in the air less horizontal control.
        {
            rb.velocity = new Vector2((horizInput * speed * Time.fixedDeltaTime)/2, rb.velocity.y);
            animator.SetBool("IsGrounded", false);
        }
        else
        {
            rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
            animator.SetBool("IsGrounded", true);

        }
    }
}
