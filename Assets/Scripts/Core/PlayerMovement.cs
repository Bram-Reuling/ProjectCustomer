using UnityEngine;

namespace ProjectCustomer.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields

        private CharacterController controller;

        public float speed = 12f;
        public float runSpeed = 17f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        
        private Vector3 velocity;

        public bool IsGrounded { get; private set; }
        public float XAxis { get; private set; }
        public float ZAxis { get; private set; }

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
            if (Input.GetButtonDown("Jump") && IsGrounded)
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
            IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (IsGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        private void MovePlayer()
        {
            XAxis = Input.GetAxis("Horizontal");
            ZAxis = Input.GetAxis("Vertical");

            var move = transform.right * XAxis + transform.forward * ZAxis;
            move = Vector3.ClampMagnitude(move, 1f);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(move * (runSpeed * Time.deltaTime));
            }
            else
            {
                controller.Move(move * (speed * Time.deltaTime));
            }
        }

        #endregion
    }
}
