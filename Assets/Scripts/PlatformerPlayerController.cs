using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    // Player movement speed
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Make jumpForce public or use SerializeField

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    public bool isGrounded;
    private float horizontalInput;

    public AudioClip jumpSound;

    private AudioSource playerAudio;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (playerAudio != null && jumpSound != null)
            {
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("yVelocity", rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("onGround", isGrounded);

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(!PlayerHealth.hitRecently)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
    }
}

