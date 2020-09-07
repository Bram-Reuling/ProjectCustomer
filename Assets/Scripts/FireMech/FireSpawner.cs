using System.Collections;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class FireSpawner : MonoBehaviour
    {
        public bool occupied = false;
        private bool stopCoroutine = false;

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
            yield return new WaitForSeconds(5f);
            if (occupied)
            {
                occupied = false;
            }

            stopCoroutine = true;
        }
    }
}