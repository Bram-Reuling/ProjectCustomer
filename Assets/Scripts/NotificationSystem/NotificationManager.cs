using System.Collections.Generic;
using UnityEngine;
using ProjectCustomer.Core;
using TMPro;

namespace ProjectCustomer.NotificationSystem
{
    public class NotificationManager : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject activePrefab;
        public TextMeshProUGUI text;
        
        public string fireStarted = "There is a Fire!";
        public string fireExtinguished = "Fire is under control!";

        private Queue<GameObject> notifications = new Queue<GameObject>();

        private void Start()
        {
            EventBroker.EventOnFireStarted += EventOnFireStarted;
            EventBroker.EventOnFireExtinguished += EventOnFireExtinguished;
        }

        private void EventOnFireStarted()
        {
            CreateNotification(fireStarted);
        }

        private void EventOnFireExtinguished()
        {
            CreateNotification(fireExtinguished);
        }

        private void CreateNotification(string notificationText)
        {
            // Instantiate Prefab
            if (activePrefab != null) return;
            activePrefab = Instantiate(prefab);   
            text = activePrefab.GetComponent<NotificationBox>().textNotification;
            text.text = notificationText;
        }
    }
}
