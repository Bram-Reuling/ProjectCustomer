using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ProjectCustomer.Core
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI currentNumberOfFiresText;
        public TextMeshProUGUI currentNumberOfFoxesInTheScene;
        public GameObject FireSprite;
        public int numberOfFiresToEndGame = 4;
        private int currentNumberOfFires;
        private int currentNumberOfFoxesDown;
        private LevelLoader levelLoader;
        public int sceneIdToSwitchTo;
        public float FlickerFastSeconds;
        public float FlickerSlowSeconds;

        private void Start()
        {
            EventBroker.EventOnFireStarted += CurrentFireIncrease;
            EventBroker.EventOnFireExtinguished += CurrentFireDecrease;

            EventBroker.EventOnFoxRevive += FoxesReviveIncrease;

            EventBroker.EventOnTimerRunOut += TimerRunOut;
            EventBroker.EventOnFoxDown += FoxDown;

            currentNumberOfFires = 0;
            currentNumberOfFoxesDown = 0;

            levelLoader = GetComponent<LevelLoader>();

            CheckFlicker();
        }

        private void Update()
        {
            currentNumberOfFiresText.text = $"{currentNumberOfFires}";

            currentNumberOfFoxesInTheScene.text = $"{DataHandler.numberOfFoxesInScene}";

            DataHandler.numberOfFoxesInScene = GameObject.FindGameObjectsWithTag("Fox").Length;
            
            if (currentNumberOfFires != numberOfFiresToEndGame) return;
            //Debug.Log("MAX FIRES! GAME OVER!");
            //EventBroker.CallEventOnMaxFires();
            DataHandler.playerLost = true;
            levelLoader.LoadNewScene(sceneIdToSwitchTo);
        }

        public void FoxDown()
        {
            currentNumberOfFoxesDown++;
        }
        
        private void FoxesReviveIncrease()
        {
            DataHandler.numberOfFoxesRevived++;
            currentNumberOfFoxesDown--;
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

        public void CheckFlicker()
        {
            if (currentNumberOfFires < numberOfFiresToEndGame - 2)
            {
                currentNumberOfFiresText.gameObject.SetActive(true);
                FireSprite.SetActive(true);
                StartCoroutine(Wait());
            }
            else if (currentNumberOfFires == numberOfFiresToEndGame - 2)
                StartCoroutine(FlickerSlow());
            else if (currentNumberOfFires == numberOfFiresToEndGame - 1)
                StartCoroutine(FlickerFast());
            else
                StartCoroutine(Wait());
        }

        IEnumerator FlickerFast()
        {
            currentNumberOfFiresText.gameObject.SetActive(true);
            FireSprite.SetActive(true);
            yield return new WaitForSeconds(FlickerFastSeconds);
            currentNumberOfFiresText.gameObject.SetActive(false);
            FireSprite.SetActive(false);
            yield return new WaitForSeconds(FlickerFastSeconds);
            CheckFlicker();
        }

        IEnumerator FlickerSlow()
        {
            currentNumberOfFiresText.gameObject.SetActive(true);
            FireSprite.SetActive(true);
            yield return new WaitForSeconds(FlickerSlowSeconds);
            currentNumberOfFiresText.gameObject.SetActive(false);
            FireSprite.SetActive(false);
            yield return new WaitForSeconds(FlickerSlowSeconds);
            CheckFlicker();
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);
            CheckFlicker();
        }

        private void OnDestroy()
        {
            EventBroker.EventOnFireStarted -= CurrentFireIncrease;
            EventBroker.EventOnFireExtinguished -= CurrentFireDecrease;

            EventBroker.EventOnFoxRevive -= FoxesReviveIncrease;

            EventBroker.EventOnTimerRunOut -= TimerRunOut;
            EventBroker.EventOnFoxDown -= FoxDown;
        }
    }
}