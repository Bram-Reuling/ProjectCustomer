using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCustomer.Core
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadNewScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
