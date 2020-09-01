using UnityEngine;

namespace ProjectCustomer.Core.Binocular
{
    public class BinocularNotEquippedState : BinocularBaseState
    {
        public override void EnterState(Binocular binocular)
        {
            binocular.binocularImage.SetActive(false);
            binocular.mainCam.focalLength = binocular.camFocalLength;
        }

        public override void Update(Binocular binocular)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                binocular.TransitionToState(binocular.EquippedState);
            }
        }

        public override void OnCollision(Binocular binocular)
        {
            
        }
    }
}
