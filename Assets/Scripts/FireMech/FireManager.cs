using System.Collections.Generic;
using ProjectCustomer.Core;
using UnityEngine;
using Random = System.Random;

namespace ProjectCustomer.FireMech
{
    public class FireManager : MonoBehaviour
    {
        public GameObject firePrefab;
        public GameObject[] fireSpots;
        public List<GameObject> activeFires;

        public float timeToSpawnNew = 60f;
        
        private Random rnd;
        private float nextTimeCall;
        public GameObject wayPointPrefab;
        public GameObject canvas;

        private void Start()
        {
            rnd = new Random();
            activeFires = new List<GameObject>();
            fireSpots = GameObject.FindGameObjectsWithTag("FireSpawner");

            Debug.Log(fireSpots.Length);

            nextTimeCall = Time.time + timeToSpawnNew;
            SetFire();
        }

        private void Update()
        {

            if (Time.time >= nextTimeCall)
            {
                SetFire();
                nextTimeCall += timeToSpawnNew;
            }
        }

        private void SetFire()
        {
            var index = rnd.Next(fireSpots.Length);

            if (!fireSpots[index].GetComponent<FireSpawner>().occupied)
            {
                var fire = (GameObject) Instantiate(firePrefab, fireSpots[index].transform.position,
                    fireSpots[index].transform.rotation);
                fireSpots[index].GetComponent<FireSpawner>().occupied = true;
                fire.GetComponent<Fire>().fireSpawner = fireSpots[index].GetComponent<FireSpawner>();
                activeFires.Add(fire);
            }
        }
    }
}

// Instantiate(firePrefab, fireSpot.transform.position, fireSpot.transform.rotation);