using System;
using System.Collections;
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
        private Random rnd;
        private float nextTimeCall;

        private void Start()
        {
            rnd = new Random();
            activeFires = new List<GameObject>();
            fireSpots = GameObject.FindGameObjectsWithTag("FireSpawner");

            Debug.Log(fireSpots.Length);

            // foreach (var fireSpot in fireSpots)
            // {
            //     if (!fireSpot.GetComponent<FireSpawner>().occupied)
            //     {
            //         var fire = (GameObject)Instantiate(firePrefab, fireSpot.transform.position, fireSpot.transform.rotation);
            //         fireSpot.GetComponent<FireSpawner>().occupied = true;
            //         fire.GetComponent<Fire>().fireSpawner = fireSpot.GetComponent<FireSpawner>();
            //     }
            // }
            nextTimeCall = Time.time + 5f;
        }

        private void Update()
        {
            if (Time.time >= nextTimeCall)
            {
                SetFire();
                nextTimeCall += 5f;
            }
        }

        private void SetFire()
        {
            Debug.Log("Picking Fire");

            var index = rnd.Next(fireSpots.Length);

            Debug.Log("Picking: " + index);
            
            if (!fireSpots[index].GetComponent<FireSpawner>().occupied)
            {
                var fire = (GameObject) Instantiate(firePrefab, fireSpots[index].transform.position,
                    fireSpots[index].transform.rotation);
                fireSpots[index].GetComponent<FireSpawner>().occupied = true;
                fire.GetComponent<Fire>().fireSpawner = fireSpots[index].GetComponent<FireSpawner>();
            }
        }
    }
}

// Instantiate(firePrefab, fireSpot.transform.position, fireSpot.transform.rotation);