using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Animals
{
    public class FireCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EventBroker.CallEventOnCloseToFire();
            }
            
            if (!other.CompareTag("Fox")) return;
            //Debug.Log("Fox is hit");
            if (!other.gameObject.GetComponent<AnimalMovement>().isRevived)
            {
                other.gameObject.GetComponent<AnimalMovement>().Death();
                EventBroker.CallEventOnFoxDown();
            }
        }
    }
}
