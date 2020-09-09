using System.Collections;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class FireSpawner : MonoBehaviour
    {
        public bool occupied = false;
        private bool stopCoroutine = false;
        public float cooldownInSeconds = 10f;

        private void Update()
        {
            if (stopCoroutine)
            {
                StopCoroutine(countDown());
                stopCoroutine = false;
            }
        }

        public void StartCountDown()
        {
            StartCoroutine(countDown());
        }

        public IEnumerator countDown()
        {
            yield return new WaitForSeconds(cooldownInSeconds);
            if (occupied)
            {
                occupied = false;
            }

            stopCoroutine = true;
        }
    }
}