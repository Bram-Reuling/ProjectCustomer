using UnityEngine;

namespace ProjectCustomer.Core.Binocular
{
    public class BinocularEquippedState : BinocularBaseState
    {
        public override void EnterState(Binocular binocular)
        {
            binocular.binocularImage.SetActive(true);
            binocular.mainCam.focalLength = binocular.camFocalLength * 4;
        }

        public override void Update(Binocular binocular)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                binocular.TransitionToState(binocular.NotEquippedState);
            }
        }

        public override void OnCollision(Binocular binocular)
        {
            
        }
    }
}
