using System.Collections;
using TMPro;
using UnityEngine;

namespace ProjectCustomer.Core
{
    [RequireComponent(typeof(LevelLoader))]
    public class StatHandler : MonoBehaviour
    {
        public StatText statText;
        public int secondsBetweenText;
        public float typeSpeed = 0.02f;
        public TextMeshProUGUI textBox;
        public int sceneToSwitchTo;

        private bool doneTyping;

        private LevelLoader levelLoader;

        private void Start()
        {
            levelLoader = GetComponent<LevelLoader>();
            doneTyping = false;
            StartCoroutine(CutScene());
        }

        IEnumerator CutScene()
        {
            foreach (var text in statText.statTextBoxes)
            {
                StartCoroutine(TypewriterEffect(text.textToDisplay));
                yield return new WaitUntil(() => doneTyping);
                yield return new WaitForSeconds(secondsBetweenText);
            }

            //yield return new WaitForSeconds(secondsBetweenText);

            var displayText = "";
            
            if (DataHandler.playerLost)
            {
                displayText = "You Lost! The fire is out of control...";
                textBox.color = Color.red;
                StartCoroutine(TypewriterEffect(displayText));

                yield return new WaitUntil(() => doneTyping);
                yield return new WaitForSeconds(secondsBetweenText);

                if (DataHandler.numberOfFoxesRevived == 1)
                {
                    displayText = "1 fox has died by the fire...";
                    textBox.color = Color.white;
                    StartCoroutine(TypewriterEffect(displayText));
                }
                else if (DataHandler.numberOfFoxesRevived == 0)
                {
                    displayText = "But not a single one died.";
                    textBox.color = Color.white;
                    StartCoroutine(TypewriterEffect(displayText));
                }
                else
                {
                    displayText = $"{DataHandler.numberOfFoxesInScene} foxes have died by the fire...";
                    textBox.color = Color.white;
                    StartCoroutine(TypewriterEffect(displayText));
                }
            }
            else
            {
                displayText = "You Won! You managed to keep the under control!";
                textBox.color = Color.green;
                StartCoroutine(TypewriterEffect(displayText));

                yield return new WaitUntil(() => doneTyping);
                yield return new WaitForSeconds(secondsBetweenText);

                displayText = $"Your day ended with a total of {DataHandler.numberOfFiresLeft} fires left...";
                textBox.color = Color.white;
                StartCoroutine(TypewriterEffect(displayText));
            }

            yield return new WaitUntil(() => doneTyping);
            yield return new WaitForSeconds(secondsBetweenText);

            displayText = $"{DataHandler.numberOfFoxesRevived} foxes rescued...";
            StartCoroutine(TypewriterEffect(displayText));

            yield return new WaitUntil(() => doneTyping);
            yield return new WaitForSeconds(secondsBetweenText);


            yield return new WaitUntil(() => doneTyping);
            yield return new WaitForSeconds(secondsBetweenText);

            displayText = $"{DataHandler.numberOfFiresPutOut} fires extinguished...";
            StartCoroutine(TypewriterEffect(displayText));

            yield return new WaitUntil(() => doneTyping);
            yield return new WaitForSeconds(secondsBetweenText);

            displayText = "Thank you for playing our game!";
            StartCoroutine(TypewriterEffect(displayText));

            yield return new WaitUntil(() => doneTyping);
            yield return new WaitForSeconds(secondsBetweenText);

            // Switch to another scene
            levelLoader.LoadNewScene(sceneToSwitchTo);
        }

        private IEnumerator TypewriterEffect(string text)
        {
            doneTyping = false;
            textBox.text = "";
            foreach (var character in text.ToCharArray())
            {
                textBox.text += character;
                yield return new WaitForSeconds(typeSpeed);
            }

            doneTyping = true;
            yield return null;
        }
    }
}