using System;
using System.Collections;
using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class Fire : MonoBehaviour
    {
        public ParticleSystem wildFire;
        public ParticleSystem embers;
        public ParticleSystem fire;
        
        public ParticleSystem water;

        private ParticleSystem.EmissionModule wildFireEmission;
        private ParticleSystem.EmissionModule embersEmission;
        private ParticleSystem.EmissionModule fireEmission;

        public float diffusePerParticle = 0.000001f;

        private float diffuseWild;
        private float diffuseEmbers;
        private float diffuseFire;

        private bool fireIsOut = false;
        private bool fireNotifSend = false;

        private void Start()
        {
            wildFireEmission = wildFire.emission;
            embersEmission = embers.emission;
            fireEmission = fire.emission;
            
            diffuseWild = wildFire.emission.rateOverTimeMultiplier * diffusePerParticle;
            diffuseEmbers = embers.emission.rateOverTimeMultiplier * diffusePerParticle;
            diffuseFire = fire.emission.rateOverTimeMultiplier * diffusePerParticle;
        }

        private void Update()
        {
            if (!fireNotifSend)
            {
                fireNotifSend = true;
                EventBroker.CallEventOnFireStarted();    
            }
            
            if (water.particleCount == 0 && !fireIsOut)
            {
                wildFireEmission.rateOverTimeMultiplier += diffuseWild;
                embersEmission.rateOverTimeMultiplier += diffuseEmbers;
                fireEmission.rateOverTimeMultiplier += diffuseFire;

                wildFireEmission.rateOverTimeMultiplier = Mathf.Clamp(wildFireEmission.rateOverTimeMultiplier, 0, 5);
                embersEmission.rateOverTimeMultiplier = Mathf.Clamp(embersEmission.rateOverTimeMultiplier, 0, 500);
                fireEmission.rateOverTimeMultiplier = Mathf.Clamp(fireEmission.rateOverTimeMultiplier, 0, 5);
            }
            
            if ((wildFireEmission.rateOverTimeMultiplier <= 0) || (embersEmission.rateOverTimeMultiplier <= 0) ||
                (fireEmission.rateOverTimeMultiplier <= 0))
            {
                if (!fireIsOut)
                {
                    fireIsOut = true;
                    StartCoroutine(DestroyTimer());
                }
            }
        }

        public void DiffuseFire()
        {
            wildFireEmission.rateOverTimeMultiplier -= diffuseWild;
            embersEmission.rateOverTimeMultiplier -= diffuseEmbers;
            fireEmission.rateOverTimeMultiplier -= diffuseFire;
        }

        IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2.5f);
            EventBroker.CallEventOnFireExtinguished();
            Destroy(gameObject);
        }
    }
}
