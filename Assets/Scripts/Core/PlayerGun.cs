using System;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class PlayerGun : MonoBehaviour
    {
        public ParticleSystem water;
        public float ammoAmount = 100f;
        public float ammoDepletionAmount = 0.01f;
        public float ammoReplenishAmount = 0.01f;
        public float ammoLowBoundary = 20f;

        private void Start()
        {
            EventBroker.EventOnWaterRefill += RefillWater;
        }

        private void Update()
        {
            DataHandler.waterParticles = water.particleCount;
            DataHandler.waterAmountLeft = ammoAmount;
            
            if (Input.GetMouseButton(0) && ammoAmount > 0)
            {
                water.Play();
                ammoAmount -= ammoDepletionAmount;
                ammoAmount = Mathf.Clamp(ammoAmount, 0, 100);
            }
            else
            {
                water.Stop();
            }
        }

        private void RefillWater()
        {
            ammoAmount += ammoReplenishAmount;
            ammoAmount = Mathf.Clamp(ammoAmount, 0, 100);
        }

        private void OnDestroy()
        {
            EventBroker.EventOnWaterRefill -= RefillWater;
        }
    }
}
