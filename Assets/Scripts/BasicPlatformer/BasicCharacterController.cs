using UnityEngine;
using System.Collections;

//--------------------------------------------
/*Basic Character Controller Includes:  
    - Basic Jumping
    - Basic grounding with line traces
    - Basic horizontal movement
 */
//--------------------------------------------

public class BasicCharacterController : MonoBehaviour
{
    protected bool facingRight = true;
    protected bool jumped;

    public float speed = 5.0f;
    public float jumpForce = 1000;

    private float horizInput;
    private float vertInput;
    private float tempJumpPower = 0.0f;
    private float jumpPower = 0.0f;
    private float tempY = 0.0f;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;

    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Get Player input 
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical"); 
    }
    

    void FixedUpdate()
    {
        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);

        //Calculate jump power.
        if (vertInput > 0 && grounded == true)
        {
            tempJumpPower += 0.06f;
            if(tempJumpPower > 1.1f)
            {
                tempJumpPower = 1.1f;
            }
        }

        if(vertInput == 0 && tempJumpPower > 0)
        {
            jumpPower = tempJumpPower;
            tempJumpPower = 0.0f;
        }

        //Move Character
        rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);

        if (jumpPower > 0 && grounded == true)
        {
            jumped = true;
            Debug.Log("Should jump");
        }

        if (jumped == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce * jumpPower));
            Debug.Log("Jumping!");
            jumpPower = 0.0f;
            jumped = false;
        }

        // Detect if character sprite needs flipping
        if (horizInput > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
