using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{ // This is to tell what state the player is in
    walk,
    attack,
    interact
}

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerState currentState; // Current state of the player
    public float speed; // Speed of the player
    private Rigidbody2D playerRigidbody; // Gives the player a rigidbody type meaning that they will have physics
    private UnityEngine.Vector3 playerChange; // Change of x and y of the player
    private Animator animator; 
    void Start()
    {
        currentState = PlayerState.walk; // sets by default the player to walk
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>(); // Imports the component Rigidbody2D
        animator.SetFloat("moveX",0);
        animator.SetFloat("moveY",-1);
    }

    // Update is called once per frame
    void Update()
    {
        playerChange = UnityEngine.Vector3.zero; // This Resets the player every frame
        playerChange.x = Input.GetAxisRaw("Horizontal"); //Gets the horizontal direction of the player
        playerChange.y = Input.GetAxisRaw("Vertical"); // gets the vertical direction of the player
        if(Input.GetButtonDown("attack")&& currentState != PlayerState.attack) // asks if the player is already attacking and if the attacking button is being pressed
        {
            StartCoroutine(AttackCo()); // Starts co routine below
        }
        else if(currentState == PlayerState.walk) //Else if stops the player so they cant run and attack, asks if the plakyer is walking
        {
            UpdateAnimationAndMove(); // Calls this function
        }
    }

    private IEnumerator AttackCo() // Starts co routine
    {
        animator.SetBool("attacking",true);// Sets attacking to true in the animator
        currentState = PlayerState.attack; // Changes the players state to attacking
        yield return null ; // Stops for 1 second
        animator.SetBool("attacking",false); // Sets attacking to false
        yield return new WaitForSeconds(.3f); // stops for a third of a second
        currentState = PlayerState.walk; //sets player state to walk
    }

    void UpdateAnimationAndMove()
    {
        if(playerChange != UnityEngine.Vector3.zero) // Checks that something is happening
        {
            movePlayer(); // moves player
            animator.SetFloat("moveX",playerChange.x);
            animator.SetFloat("moveY",playerChange.y);
            animator.SetBool("moving",true);
        }
        else
        {
            animator.SetBool("moving",false);
        };
    }

    void movePlayer()
    {
        playerChange.Normalize();
        playerRigidbody.MovePosition(
             transform.position + playerChange * speed * Time.deltaTime
        );
    }
}