using UnityEngine;

namespace ProjectCustomer.Core.Binocular_States
{
    public class BinocularEquippedState : BinocularBaseState
    {
        public override void EnterState(BinocularMain binocular)
        {
            binocular.binocularImage.SetActive(true);
            binocular.mainCam.focalLength = binocular.camFocalLength * 4;
            
            binocular.playerCam.mouseSensitivity = 50;
        }

        public override void Update(BinocularMain binocular)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                binocular.TransitionToState(binocular.NotEquippedState);
            }
        }

        public override void OnCollision(BinocularMain binocular)
        {
            
        }
    }
}
