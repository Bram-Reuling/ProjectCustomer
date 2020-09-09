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
                var dist = Vector3.Distance(transform.position, player.transform.position);
                var clampedDist = Mathf.Clamp(dist, 0, 100);

                var transformLocalScale = transform.localScale;
                transformLocalScale.x = 0.5f * clampedDist / 750f;
                transformLocalScale.y = 0.5f * clampedDist / 750f;

                transform.localScale = transformLocalScale;

            }
        }
    }
}
