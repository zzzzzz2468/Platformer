using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //sets the variables
    private bool canMove = true;
    public LayerMask platformLayerMask;
    public Rigidbody2D player;
    public float speed = 3;
    public Animator anim;
    public float jumpPower = 3;

    void Start()
    {
        //gets the components
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //detects if player can move and then moves, in case i want to prevent player from moving
        if(canMove)
            Movement();

        //detects if player is grounded and space is pressed, which allows the player to jump
        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    //movement and setting move animations
    void Movement()
    {
        float move = Input.GetAxis("Horizontal") * speed;

        player.velocity = new Vector2(move, player.velocity.y);

        anim.SetFloat("Speed", move);

        if(player.velocity == Vector2.zero)
            anim.SetBool("Running", false);
        else
            anim.SetBool("Running", true);
    }

    //player jumping
    void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpPower);
    }

    //detects if player is grounded
    bool isGrounded()
    {
        return Physics2D.Raycast(player.transform.position, Vector2.down, 0.25f, platformLayerMask);
    }
}
