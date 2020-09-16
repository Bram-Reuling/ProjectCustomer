using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Audio
{

    public class PlayerFootsteps : MonoBehaviour
    {

        public AudioClip walkSound;
        public AudioClip walkSound2;
        public float walkfootstepDelay;
        public float runfootstepDelay;
        public float chosenfootstepDelay;

        private float nextFootstep = 0;

        // Start is called before the first frame update
        void Start()
        {
            chosenfootstepDelay = walkfootstepDelay;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                chosenfootstepDelay = runfootstepDelay;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                chosenfootstepDelay = walkfootstepDelay;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                nextFootstep -= Time.deltaTime;

                if (nextFootstep <= 0)
                {

                    float fRand = Random.Range(0.0f, 1.0f);

                    if (fRand <= 0.5f)
                    {
                        GetComponent<AudioSource>().PlayOneShot(walkSound, 0.7f);
                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(walkSound2, 0.7f);
                    }
                    nextFootstep += chosenfootstepDelay;
                }



            }

        }
    }

}