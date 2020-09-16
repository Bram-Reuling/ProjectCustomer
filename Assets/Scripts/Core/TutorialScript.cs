using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class TutorialScript : MonoBehaviour
    {
        public GameObject[] waypoints,canvas;
        public Transform ogtransofrm;
        public float cammovespeed = 5f;

        public bool bin = false, camp = false, lake = false, fox = false;

        // Start is called before the first frame update
        void Start()
        {
            ogtransofrm = Camera.main.transform;

            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);

        
        }

        // Update is called once per frame
        void Update()
        {
            if(bin)
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, waypoints[0].transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, waypoints[0].transform.rotation, cammovespeed * Time.deltaTime);
            }
            else if (camp)
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, waypoints[1].transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, waypoints[1].transform.rotation, cammovespeed * Time.deltaTime);
            }
            else if (lake)
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, waypoints[2].transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, waypoints[2].transform.rotation, cammovespeed * Time.deltaTime);
            }
            else if (fox)
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, waypoints[3].transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, waypoints[3].transform.rotation, cammovespeed * Time.deltaTime);
            }
            else
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, ogtransofrm.transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, ogtransofrm.transform.rotation, cammovespeed * Time.deltaTime);
            }
        }

        public void startTut()
        {
            StartCoroutine(Delay());
        }

        void Binocular()
        {
            bin = true;
            camp = false;
            lake = false;
            fox = false;
            canvas[0].SetActive(true);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
        }

        void Cmapfire()
        {
            bin = false;
            camp = true;
            lake = false;
            fox = false;
            canvas[0].SetActive(false);
            canvas[1].SetActive(true);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
        }

        void Lake()
        {
            bin = false;
            camp = false;
            lake = true;
            fox = false;
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(true);
            canvas[3].SetActive(false);
        }

        void Fox()
        {
            bin = false;
            camp = false;
            lake = false;
            fox = true;
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(true);
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