using System.Collections.Generic;
using UnityEngine;
using ProjectCustomer.Core;

namespace ProjectCustomer.NotificationSystem
{
    public class NotificationManager : MonoBehaviour
    {
        public string fireStarted = "There is a Fire!";
        public string fireExtinguished = "Fire is under control!";
        public string ammoLow = "Ammo is low!";
        public string ammoEmpty = "You have no ammo left!";
        public string ammoRefillStarted = "Refilling ammo!";
        public string ammoFull = "Ammo is full!";

        private Queue<string> notifications = new Queue<string>();

        private void Start()
        {
            EventBroker.EventOnFireStarted += EventOnFireStarted;
            EventBroker.EventOnFireExtinguished += EventOnFireExtinguished;
            EventBroker.EventOnAmmoAlmostEmpty += EventOnAmmoAlmostEmpty;
            EventBroker.EventOnAmmoEmpty += EventOnAmmoEmpty;
            EventBroker.EventOnAmmoRefillStarted += EventOnAmmoRefillStarted;
            EventBroker.EventOnAmmoFull += EventOnAmmoFull;
        }

        private void EventOnFireStarted()
        {
            Debug.Log(fireStarted);
        }

        private void EventOnFireExtinguished()
        {
            Debug.Log(fireExtinguished);
        }

        private void EventOnAmmoAlmostEmpty()
        {
            Debug.Log(ammoLow);
        }

        private void EventOnAmmoEmpty()
        {
            Debug.Log(ammoEmpty);
        }

        private void EventOnAmmoRefillStarted()
        {
            Debug.Log(ammoRefillStarted);
        }

        private void EventOnAmmoFull()
        {
            Debug.Log(ammoFull);
        }
    }
}
