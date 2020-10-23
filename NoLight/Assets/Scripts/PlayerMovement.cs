using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float speed = 2.5f;
    private float jumpForce = 5;
    Rigidbody2D body;

    public bool isGrounded;
    public LayerMask groundLayer;

    private Collider2D characterCollider;

    private float offEdgeTime = 0.1f;
    private float offEdegeCounter;

    float jumpBufferTime = 0.1f,jumpBufferCounter;
    float movement;

    const string isJumping = "isJumping";

    private GameObject p1, p2;

    Animator animator;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        characterCollider = GetComponent<Collider2D>();
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //finding the ground
        isGrounded = Physics2D.IsTouchingLayers(characterCollider, groundLayer);

        //off edge jump 
        if (isGrounded)
        {
            offEdegeCounter = offEdgeTime;
        }
        else
        {
            offEdegeCounter -= Time.deltaTime;
        }

        //jump buffer, allow the player to jump again in 0.1sec before they reach the ground.
        if (Input.GetButton("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        movement = Input.GetAxis("Horizontal");

        if (jumpBufferCounter >= 0 && offEdegeCounter > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpBufferCounter = 0;
            animator.SetTrigger("isJumping");
        }
        if(Input.GetButtonUp("Jump")&& body.velocity.y > 0)
        {   //if the player hold down the space bar then they can jump a little bit higher.
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * .5f);
            animator.SetTrigger("isJumping");
        }
    }

    private void FixedUpdate()
    {
        p1.transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        p2.transform.position -= new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }
}
