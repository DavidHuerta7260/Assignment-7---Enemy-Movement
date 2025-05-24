using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EnemyMoveWalkingChase : MonoBehaviour
{
    public float chaseRange = 4f;
    public float enemyMovementSpeed = 1.5f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // ✅ Correct assignment
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 playerDirection = playerTransform.position - transform.position;
        float distanceToPlayer = playerDirection.magnitude;

        if (distanceToPlayer <= chaseRange)
        {
            playerDirection.Normalize();
            playerDirection.y = 0f;

            FacePlayer(playerDirection);

            if (IsGroundedAhead())
            {
                MoveTowardsPlayer(playerDirection);
            }
            else
            {
                StopMoving();
                Debug.Log("No ground ahead");
            }
        }
        else
        {
            StopMoving();
        }
    }

    private bool IsGroundedAhead()
    {
        float groundCheckDistance = 2.0f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        Vector2 direction = Vector2.down;
        float offsetX = playerTransform.position.x < transform.position.x ? -0.5f : 0.5f;
        Vector2 origin = new Vector2(transform.position.x + offsetX, transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, groundCheckDistance, groundLayer);
        Debug.DrawRay(origin, direction * groundCheckDistance, Color.red); // Optional for debugging

        return hit.collider != null;
    }

    private void FacePlayer(Vector2 playerDirection)
    {
        if (playerDirection.x < 0)
        {
            sr.flipX = false; // Faces left
        }
        else
        {
            sr.flipX = true;  // Faces right
        }
    }


    private void MoveTowardsPlayer(Vector2 playerDirection)
    {
        rb.velocity = new Vector2(playerDirection.x * enemyMovementSpeed, rb.velocity.y);
        anim.SetBool("isMoving", true);
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetBool("isMoving", false);
    }
}