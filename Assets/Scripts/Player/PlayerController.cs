using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canMove = true;
    public LayerMask platformLayerMask;
    public Rigidbody2D player;
    public float speed = 3;
    public Animator anim;
    public float jumpPower = 3;

    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(canMove)
            Movement();
        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

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

    void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpPower);
    }

    bool isGrounded()
    {
        return Physics2D.Raycast(player.transform.position, Vector2.down, 0.25f, platformLayerMask);
    }
}
