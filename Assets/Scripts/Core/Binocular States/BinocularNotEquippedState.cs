using UnityEngine;

namespace ProjectCustomer.Core.Binocular_States
{
    public class BinocularNotEquippedState : BinocularBaseState
    {
        public override void EnterState(BinocularMain binocular)
        {
            binocular.binocularImage.SetActive(false);
            binocular.mainCam.focalLength = binocular.camFocalLength;

            binocular.playerCam.mouseSensitivity = binocular.origSens;
            
            EventBroker.CallEventOnBinocularUnEquip();
        }

        public override void Update(BinocularMain binocular)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                binocular.TransitionToState(binocular.EquippedState);
            }
        }

        public override void OnCollision(BinocularMain binocular)
        {
            
        }
    }
}
