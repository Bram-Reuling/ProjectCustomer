using UnityEngine;

namespace ProjectCustomer.Animals
{
    public class FireCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Fox")) return;
            Debug.Log("Fox is hit");
            other.gameObject.GetComponent<AnimalMovement>().Death();
        }
    }
}
