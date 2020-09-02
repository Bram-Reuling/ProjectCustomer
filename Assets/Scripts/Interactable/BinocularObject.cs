using System;
using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Interactable
{
    public class BinocularObject : MonoBehaviour, IInteractable
    {
        private void Start()
        {
            EventBroker.EventOnBinocularPickUp += Interacted;
        }

        public void Interacted()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            EventBroker.EventOnBinocularPickUp -= Interacted;
        }
    }
}
