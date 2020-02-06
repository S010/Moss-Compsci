using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; // Speed of the player
    private Rigidbody2D playerRigidbody; // Gives the player a rigidbody type meaning that they will have physics
    private UnityEngine.Vector3 playerChange;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>(); // Imports the component Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        playerChange = UnityEngine.Vector3.zero; // This Resets the player every frame
        playerChange.x = Input.GetAxisRaw("Horizontal");
        playerChange.y = Input.GetAxisRaw("Vertical");
        if(playerChange != UnityEngine.Vector3.zero) // Checks that something is happening
        {
            movePlayer();
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
        playerRigidbody.MovePosition(
             transform.position + playerChange * speed * Time.deltaTime
        );
    }
}