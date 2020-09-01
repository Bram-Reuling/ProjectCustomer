using UnityEngine;

namespace ProjectCustomer.Core.Player
{
    public class PlayerHeadBob : MonoBehaviour
    {

        #region Fields

        public float walkingBobSpeed = 14f;
        public float runningBobSpeed = 18f;
        public float amountOfBobbing = 0.05f;
        public PlayerMovement controller;

        private float defaultPosY = 0;
        private float timer = 0;

        #endregion

        #region Startup

        private void Start()
        {
            defaultPosY = transform.localPosition.y;
        }

        #endregion

        private void Update()
        {
            // Is the player moving and on the ground?
            if ((Mathf.Abs(controller.XAxis) > 0.1f || Mathf.Abs(controller.ZAxis) > 0.1f) && controller.IsGrounded)
            {
                // Yes
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    timer += Time.deltaTime * runningBobSpeed;
                }
                else
                {
                    timer += Time.deltaTime * walkingBobSpeed;
                }
                
                var localPosition = transform.localPosition;
                localPosition = new Vector3(localPosition.x, defaultPosY + Mathf.Sin(timer) * amountOfBobbing, localPosition.z);
                transform.localPosition = localPosition;
            }
            else
            {
                // No
                timer = 0;
                var localPosition = transform.localPosition;
                localPosition = new Vector3(localPosition.x, Mathf.Lerp(localPosition.y, defaultPosY, Time.deltaTime * walkingBobSpeed), localPosition.z);
                transform.localPosition = localPosition;
            }
        }
    }
}
