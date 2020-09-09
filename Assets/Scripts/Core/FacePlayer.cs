using UnityEngine;

namespace ProjectCustomer.Core
{
    public class FacePlayer : MonoBehaviour
    {
        private Transform player;
        // Start is called before the first frame update
        private void Start()
        {
            player = GameObject.Find("Player").transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if (player != null)
            {
                transform.LookAt(player, Vector3.up);
            }
        }
    }
}
