using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] float moveSpeed = 5f;
        private Vector3 moveDirection;
        private Player.PlayerAttackController attackController;
        private Torch.TorchController torchController;
        private bool isJumping = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            attackController = GetComponent<Player.PlayerAttackController>();
            torchController = GetComponent<Torch.TorchController>();
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
                if (torchController != null)
                {
                    torchController.AddTorchOnJump();
                }

                isJumping = true;
                animator.SetBool("IsJumping", true);
            }

            // attack
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
}