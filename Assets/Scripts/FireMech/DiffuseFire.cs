using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class DiffuseFire : MonoBehaviour
    {
        private ParticleSystem water;
        private List<ParticleCollisionEvent> collisionEvents;
        private int eventCount = 0;

        private void Awake()
        {
            water = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            collisionEvents = new List<ParticleCollisionEvent>();
        }
        
        private void OnParticleCollision(GameObject other)
        {
            var collCount = water.GetSafeCollisionEventSize();

            eventCount = water.GetCollisionEvents(other, collisionEvents);

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
