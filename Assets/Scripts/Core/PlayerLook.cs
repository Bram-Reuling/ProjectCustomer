using System;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class PlayerLook : MonoBehaviour
    {
        #region Fields

        public Transform player;
        [Range(1, 1000)] public int mouseSensitivity = 100;

        private float xRotation = 0f;

        #endregion

        #region Start Up

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion

        #region Update

        private void Update()
        {
            CamControl();

            RaycastHit hit;
            Debug.DrawRay(transform.position, Camera.main.transform.forward * 5, Color.blue);
            if (!Physics.Raycast(transform.position, transform.forward, out hit, 10)) return;
            if (hit.transform.GetComponent<IInteractable>() == null) return;

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.name.Equals("Binoculars"))
            {
                EventBroker.CallEventOnBinocularPickUp();
            }
            else if (Input.GetKey(KeyCode.E) && hit.collider.gameObject.name.Equals("WaterRefill"))
            {
                EventBroker.CallEventOnWaterRefill();
            }
        }
        
        private void CamControl()
        {
            #if UNITY_EDITOR
                var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            #elif UNITY_WEBGL
                var mouseX = Input.GetAxis("Mouse X") * 5;
                var mouseY = Input.GetAxis("Mouse Y") * 5;    
            #endif

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            player.Rotate(Vector3.up * mouseX);
        }

        #endregion
    }
}
