using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownCharacterController : MonoBehaviour
{
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    //Reference to attached sprite renderer.
    private SpriteRenderer renderer;

    private Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    public Vector2 mousePos;
    public Vector3 worldMousePos;
    public bool canMove;
    public bool ePressed;

    private Camera camera;

    [Header("Movement parameters")]
    [SerializeField] private float playerMaxSpeed = 100f;

    /// <summary>
    /// When the script first initialises
    /// </summary>
    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = CharacterCreation.playerSkinColor;
        animator.SetInteger("BodyType", CharacterCreation.playerBodyType);
        camera = Camera.main;
        canMove = true;
    }
    /// <summary>
    /// When a fixed update cycle is called
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        if(canMove)
        {
            rb.velocity = playerDirection * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = playerDirection * 0;
        }

    }

    /// <summary>
    /// Called when the player wants to move in a certain direction
    /// </summary>
    /// <param name="context"></param>
    public void OnPlayerInputMove(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            //Was the action just cancelled (released)? If so, set
            //speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
            return;
        }

        //Otherwise, if the context wasn't performed, don't run
        //the code below
        if (!context.performed)
            return;

        //Read the direction that the player wants to move, from the
        //keys that have been pressed
        Vector2 direction = context.ReadValue<Vector2>();

        //Set the player's direction to whatever it is
        playerDirection = direction;

        /*Set animator parameters
        animator.SetFloat("Horizontal", playerDirection.x);
        animator.SetFloat("Vertical", playerDirection.y);*/
        animator.SetFloat("Speed", playerDirection.magnitude);

        //And set the speed to 1, so they move!
        playerSpeed = 1f;
    }

    public void ReadMouse(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        mousePos = context.ReadValue<Vector2>();
        worldMousePos = camera.ScreenToWorldPoint(mousePos);
        animator.SetFloat("Horizontal", worldMousePos.x);
        animator.SetFloat("Vertical", worldMousePos.y); 
    }

    public void OnPlayerEInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            ePressed = true;
        }
        else
        {
            ePressed = false;
        }
    }
}
