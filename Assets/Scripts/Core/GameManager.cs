using UnityEngine;
using TMPro;

namespace ProjectCustomer.Core
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI currentNumberOfFiresText;
        public int numberOfFiresToEndGame = 4;
        private int currentNumberOfFires;
        private LevelLoader levelLoader;
        public int sceneIdToSwitchTo;

        private void Start()
        {
            EventBroker.EventOnFireStarted += CurrentFireIncrease;
            EventBroker.EventOnFireExtinguished += CurrentFireDecrease;

            EventBroker.EventOnFoxRevive += FoxesReviveIncrease;

            EventBroker.EventOnTimerRunOut += TimerRunOut;

            currentNumberOfFires = 0;

            levelLoader = GetComponent<LevelLoader>();
        }

        private void Update()
        {
            currentNumberOfFiresText.text = $"Current Number of Fires: {currentNumberOfFires}";

            DataHandler.numberOfFoxesInScene = GameObject.FindGameObjectsWithTag("Fox").Length;
            
            if (currentNumberOfFires != numberOfFiresToEndGame) return;
            //Debug.Log("MAX FIRES! GAME OVER!");
            //EventBroker.CallEventOnMaxFires();
            DataHandler.playerLost = true;
            levelLoader.LoadNewScene(sceneIdToSwitchTo);
        }

        private void FoxesReviveIncrease()
        {
            DataHandler.numberOfFoxesRevived++;
        }

        private void TimerRunOut()
        {
            DataHandler.playerLost = false;
            levelLoader.LoadNewScene(sceneIdToSwitchTo);
        }
        
        private void CurrentFireIncrease()
        {
            currentNumberOfFires++;
            DataHandler.numberOfFiresLeft++;
        }

        private void CurrentFireDecrease()
        {
            currentNumberOfFires--;
            DataHandler.numberOfFiresLeft--;
            DataHandler.numberOfFiresPutOut++;
        }
    }
}