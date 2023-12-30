using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Vector2 moveDir; 
    private Rigidbody2D rb; 
    private Knockback knockback; 
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        knockback = GetComponent<Knockback>(); 
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (knockback.GettingKnockBack) 
        {
            return; 
        }
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime)); 
        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void MoveTo(Vector2 targetPosition) 
    {
        moveDir = targetPosition; 
    }

    public void FollowTo(Vector2 targetPosition)
    {
        moveDir = (targetPosition - (Vector2)transform.position).normalized / 2f;
    }   
    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }
}
