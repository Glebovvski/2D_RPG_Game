using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody2D playerRigidbody2D;

    private bool facingRight;

    private Animator anim;

    private GameObject playerSprite;

    public float speed = 4.0f;

    private bool grounded = false;

    private Transform groundCheck;

    [HideInInspector]
    public bool jump = false;
    public float jumpForce = 0.1f;

    private void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerSprite = transform.Find("PlayerSprite").gameObject;
        anim = playerSprite.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float movePlayerVector = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(movePlayerVector));

        playerRigidbody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidbody2D.velocity.y);

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (movePlayerVector>0 && !facingRight)
        {
            Flip();
        }
        else if(movePlayerVector<0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("jump");

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = playerSprite.transform.localScale;
        theScale.x *= -1;
        playerSprite.transform.localScale = theScale;
    }
}
