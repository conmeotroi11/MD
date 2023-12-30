using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    private InputSystemControl inputActions;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool playerFlipx = false;
    public bool PlayerFlipx { get { return playerFlipx; } }
    [SerializeField] private float dashSpeed;
    private bool isDashing = false;
    public bool IsDasing { get { return isDashing; } }
    private Knockback knockback;
    public bool canMove = true;
    protected override void Awake()
    {
        base.Awake();
        inputActions = new InputSystemControl();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }
    private void Start()
    {
        inputActions.Attack.Dash.performed += _ => PlayerDash();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerFlip();
    }

    private void Update()
    {
        PlayerInput();
    }


    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void PlayerInput()
    {
            movement = inputActions.Movement.Move.ReadValue<Vector2>();
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);     
    }

    private void PlayerMove()
    {
        if (knockback.GettingKnockBack || !canMove) { return; }
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));
    }

    private void PlayerFlip()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mousePos.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
            playerFlipx = true;
        }
        else if(mousePos.x >playerScreenPoint.x)
        {
            spriteRenderer.flipX =false;
            playerFlipx = false;
        }
    }

    private void PlayerDash()
    {
        if (!isDashing) 
        {
            isDashing = true;
            PlayerHealth.Instance.canTakeDame = false;
            moveSpeed += dashSpeed;
            SFXManager.Instance.PlayAudio(2);
            animator.SetTrigger("Dashing");
            StartCoroutine(EndPlayerDashRoutine());
              

        }
    }

    private IEnumerator EndPlayerDashRoutine() 
    {
        float dashTime = 0.2f;
        float dashCooldown = 0.5f;
        yield return new WaitForSeconds(dashTime); 
        moveSpeed -= dashSpeed;
        PlayerHealth.Instance.canTakeDame = true;
        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;

        
    }

 

}
