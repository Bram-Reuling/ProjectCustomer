using UnityEngine;
using TMPro;

namespace ProjectCustomer.Core
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI currentNumberOfFiresText;
        public int numberOfFiresToEndGame = 4;
        private int currentNumberOfFires;

        private void Start()
        {
            EventBroker.EventOnFireStarted += CurrentFireIncrease;
            EventBroker.EventOnFireExtinguished += CurrentFireDecrease;

            currentNumberOfFires = 0;
        }

        private void Update()
        {
            currentNumberOfFiresText.text = $"Current Number of Fires: {currentNumberOfFires}";
            
            if (currentNumberOfFires != numberOfFiresToEndGame) return;
            //Debug.Log("MAX FIRES! GAME OVER!");
            EventBroker.CallEventOnMaxFires();
        }

        private void CurrentFireIncrease()
        {
            currentNumberOfFires++;
        }

        private void CurrentFireDecrease()
        {
            currentNumberOfFires--;
        }
    }
}