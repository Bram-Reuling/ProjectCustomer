using System;
using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Animals
{
    public class DeSpawnCollision : MonoBehaviour
    {
        private SphereCollider sphereCollider;
        
        private void Start()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.enabled = false;
            EventBroker.EventOnFoxRevive += FoxRevive;
        }

        private void FoxRevive()
        {
            sphereCollider.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hit");
            if (!other.CompareTag("Fox")) return;
            Debug.Log("Fox is hit");
            other.gameObject.GetComponent<AnimalMovement>().DeSpawn();
        }
    }
}