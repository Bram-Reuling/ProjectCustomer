using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCustomer.Core
{
    public class LevelLoader : MonoBehaviour
    {
        public GameObject game;
        public GameObject loadScreen;

        public TextMeshProUGUI text;
        public Animator transition;
        
        public void LoadNewScene(int scene)
        {
            // game.SetActive(false);
            // loadScreen.SetActive(true);
            //SceneManager.LoadScene(scene);
            StartCoroutine(LoadAsynchronously(scene));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            transition.SetTrigger("Start");
            
            yield return new WaitForSeconds(1f);

            var operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / .9f);
                progress *= 100;
                text.text = "Loading...";

                yield return null;
            }
        }
    }
}
