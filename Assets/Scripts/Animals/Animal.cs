using UnityEngine;
using ProjectCustomer.Core;

namespace ProjectCustomer.Animals
{
    public class Animal : MonoBehaviour, IInteractable
    {
        public void Interacted()
        {
            Debug.Log("Interacted");
            Destroy(gameObject);
        }
    }
}
