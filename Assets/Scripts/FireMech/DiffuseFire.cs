using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class DiffuseFire : MonoBehaviour
    {
        private ParticleSystem water;
        private ParticleCollisionEvent[] CollisionEvents;
        private int eventCount = 0;

        private void Awake()
        {
            water = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            CollisionEvents = new ParticleCollisionEvent[8];
        }

        private void Update()
        {
            Debug.Log(water.particleCount);
        }

        private void OnParticleCollision(GameObject other)
        {
            var collCount = water.GetSafeCollisionEventSize();
        
            if (collCount > CollisionEvents.Length)
                CollisionEvents = new ParticleCollisionEvent[collCount];

            eventCount = water.GetCollisionEvents(other, CollisionEvents);

            for (var i = 0; i < eventCount; i++)
            {
                var deafenFire = other.gameObject.GetComponent<Fire>();
                if (deafenFire != null)
                {
                    deafenFire.DiffuseFire();
                }
            }
        }
    }
}
