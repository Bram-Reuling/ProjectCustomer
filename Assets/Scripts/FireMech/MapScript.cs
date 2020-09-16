using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;




namespace ProjectCustomer.FireMech
{

    public class MapScript : MonoBehaviour
    {

        private float Map(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }


        public GameObject map;
        public GameObject player;
        public GameObject[] markers;
        public GameObject[] spawnPoints;
        public GameObject GameManager;


        public GameObject playerchar;

        public float x, z,mappedx,mappedz;

     
        RectTransform m_RectTransform;
        RectTransform p_RectTransform;


        // Start is called before the first frame update
        void Start()
        {
            map.SetActive(false);
            player.SetActive(false);

            m_RectTransform = map.GetComponent<RectTransform>();
            p_RectTransform = player.GetComponent<RectTransform>();

            spawnPoints = GameObject.FindGameObjectsWithTag("FireSpawner");

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                markers[i].SetActive(false);
            }

            // (0,0) on the player is -353 -312
            // 500 500 on the player is 350 312



        }

        // Update is called once per frame
        void Update()
        {

            for (int i=0;i < spawnPoints.Length;i++)
            {
                if(spawnPoints[i].GetComponent<FireSpawner>().occupied)
                    markers[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Map(spawnPoints[i].transform.position.x, 0, 500, -475, 475), Map(spawnPoints[i].transform.position.z, 0, 500, -475, 475));
                else
                    markers[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-100000,-100000);
            }

            x = playerchar.transform.position.x;
            z = playerchar.transform.position.z;

            mappedx = Map(x, 0, 500, -475, 475);
            mappedz = Map(z, 0, 500, -475, 475);


            player.GetComponent<RectTransform>().anchoredPosition = new Vector2(mappedx, mappedz);


            if (Input.GetKeyDown(KeyCode.Tab))
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (spawnPoints[i].GetComponent<FireSpawner>().occupied)
                        markers[i].SetActive(true);
                }
                map.SetActive(true);
                player.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (spawnPoints[i].GetComponent<FireSpawner>().occupied)
                        markers[i].SetActive(false);
                }
                map.SetActive(false);
                player.SetActive(false);
            }

        }



    }

}