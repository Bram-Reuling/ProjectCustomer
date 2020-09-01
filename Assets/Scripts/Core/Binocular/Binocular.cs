using System;
using UnityEngine;

namespace ProjectCustomer.Core.Binocular
{
    public class Binocular : MonoBehaviour
    {
        #region Fields

        public GameObject binocularImage;
        
        public Camera mainCam;
        public float camFocalLength;

        private BinocularBaseState currentState;

        public readonly BinocularEquippedState EquippedState = new BinocularEquippedState();
        public readonly BinocularNotEquippedState NotEquippedState = new BinocularNotEquippedState();

        #endregion

        #region Startup

        private void Start()
        {
            mainCam = Camera.main;
            if (mainCam != null) camFocalLength = mainCam.focalLength;
            TransitionToState(NotEquippedState);
        }

        #endregion

        public void TransitionToState(BinocularBaseState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        private void Update()
        {
            currentState.Update(this);
        }
    }
}
