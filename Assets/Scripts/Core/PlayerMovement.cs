using System;
using UnityEngine;

namespace TimeLess.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields

        private CharacterController controller;

        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        
        private Vector3 velocity;
        private bool isGrounded;

        #endregion

        #region Start Up

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        #endregion

        #region Updates

        private void Update()
        {
            GroundCheck();

            MovePlayer();

            Jump();
            
            ApplyGravity();
        }

        #endregion

        #region Movement

        private void Jump()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        private void ApplyGravity()
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        private void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        private void MovePlayer()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var move = transform.right * x + transform.forward * z;
            move = Vector3.ClampMagnitude(move, 1f);
            
            controller.Move(move * (speed * Time.deltaTime));
        }

        #endregion
    }
}
