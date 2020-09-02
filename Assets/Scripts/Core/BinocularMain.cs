using System;
using ProjectCustomer.Core.Binocular_States;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class BinocularMain : MonoBehaviour
    {
        #region Fields

        public GameObject binocularImage;

        public Camera mainCam;
        public float camFocalLength;

        public PlayerLook playerCam;
        public int origSens;

        private BinocularBaseState currentState;

        public readonly BinocularEquippedState EquippedState = new BinocularEquippedState();
        public readonly BinocularNotEquippedState NotEquippedState = new BinocularNotEquippedState();

        #endregion

        #region Startup

        private void Start()
        {
            EventBroker.EventOnBinocular += TestEvent;
            
            mainCam = Camera.main;

            playerCam = GetComponent<PlayerLook>();
            origSens = playerCam.mouseSensitivity;
            
            if (mainCam != null) camFocalLength = mainCam.focalLength;
            TransitionToState(NotEquippedState);
        }

        #endregion

        private static void TestEvent()
        {
            Debug.Log("Event Called!");
        }
        
        public void TransitionToState(BinocularBaseState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        private void Update()
        {
            currentState.Update(this);
        }

        private void OnDestroy()
        {
            EventBroker.EventOnBinocular -= TestEvent;
        }
    }
}
