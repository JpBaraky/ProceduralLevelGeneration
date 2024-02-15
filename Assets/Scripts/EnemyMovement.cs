using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
public float speed = 2f;
    public Transform groundDetection;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;

    private bool facingRight = true;

    void Update()
    {
        // Move the enemy
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Check for ground ahead
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f, groundLayer);

        // Check for obstacles (wall or ground) ahead
        RaycastHit2D obstacleInfo = Physics2D.Raycast(groundDetection.position, transform.right, 0.1f, obstacleLayer);

        if (!groundInfo.collider || obstacleInfo.collider)
        {
            // If there is no ground ahead or there's an obstacle, turn around
            Flip();
        }
    }

    void Flip()
    {
        // Change the direction the enemy is facing
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}