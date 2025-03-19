using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    private PlayerAttackController attackController;
    private bool isJumping = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackController = GetComponent<PlayerAttackController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, moveY, 0).normalized;

        // animation speed
        animator.SetFloat("Speed", moveDirection.magnitude);
        animator.SetFloat("VerticalSpeed", moveY);

        // left => right movement
        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // right => left movement
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // move player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        } 

        // attck
        if (Input.GetKeyDown(KeyCode.F) && !isJumping)
        {
            animator.SetBool("IsAttacking", true);
            if (attackController != null)
            {
                attackController.Attack();
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void OnJumpAnimationEnd()
    {
        isJumping = false; 
        animator.SetBool("IsJumping", false);
    }
}