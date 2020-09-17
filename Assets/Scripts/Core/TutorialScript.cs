using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public class TutorialScript : MonoBehaviour
    {
        public GameObject[] waypoints, canvas;
        public GameObject MainUI;
        public Transform ogtransofrm;
        public float cammovespeed;

        public bool bin = false, camp = false, lake = false, fox = false, last = false;

        // Start is called before the first frame update
        void Start()
        {
            ogtransofrm = Camera.main.transform;

            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);


        }

        // Update is called once per frame
        void Update()
        {
            if (bin)
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
            else if (last)
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, waypoints[4].transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, waypoints[4].transform.rotation, cammovespeed * Time.deltaTime);
            }
            else
            {
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, ogtransofrm.transform.position, cammovespeed * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, ogtransofrm.transform.rotation, cammovespeed * Time.deltaTime);
            }
        }

        public void endTut()
        {
            MainUI.SetActive(true);
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);

        }

        public void startTut()
        {
            MainUI.SetActive(false);
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);
            StartCoroutine(Delay());
        }

        void Binocular()
        {
            bin = true;
            camp = false;
            lake = false;
            fox = false;
            last = false;
            canvas[0].SetActive(true);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);
        }

        void Cmapfire()
        {
            bin = false;
            camp = true;
            lake = false;
            fox = false;
            last = false;
            canvas[0].SetActive(false);
            canvas[1].SetActive(true);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);
        }

        void Lake()
        {
            bin = false;
            camp = false;
            lake = true;
            fox = false;
            last = false;
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(true);
            canvas[3].SetActive(false);
            canvas[4].SetActive(false);
        }

        void Fox()
        {
            bin = false;
            camp = false;
            lake = false;
            fox = true;
            last = false;
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(true);
            canvas[4].SetActive(false);
        }

        void Last()
        {
            bin = false;
            camp = false;
            lake = false;
            fox = false;
            last = true;
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
            canvas[3].SetActive(false);
            canvas[4].SetActive(true);
        }

        IEnumerator Delay()
        {

            Binocular();
            yield return new WaitForSeconds(7f);
            cammovespeed = cammovespeed / 2;
            Cmapfire();
            yield return new WaitForSeconds(16f);
            cammovespeed = cammovespeed * 2;
            Lake();
            yield return new WaitForSeconds(10f);
            Fox();
            yield return new WaitForSeconds(8f);
            Last();
        }
    }

}