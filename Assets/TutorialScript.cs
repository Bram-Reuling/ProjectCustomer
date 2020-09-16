using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class TutorialScript : MonoBehaviour
    {
        public GameObject[] waypoints;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void Binocular()
        {

        }

        void Cmapfire()
        {

        }

        void Lake()
        {

        }

        void Fox()
        {

        }

        IEnumerator Delay()
        {
            Binocular();
            yield return new WaitForSeconds(5f);
            Cmapfire();
            yield return new WaitForSeconds(5f);
            Lake();
            yield return new WaitForSeconds(5f);
            Fox();
        }
    }

}