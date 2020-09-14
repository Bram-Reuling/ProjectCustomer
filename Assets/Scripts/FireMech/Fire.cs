using System.Collections;
using ProjectCustomer.Core;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectCustomer.FireMech
{
    public class Fire : MonoBehaviour
    {
        public ParticleSystem wildFire;
        public ParticleSystem embers;
        public ParticleSystem fire;

        private ParticleSystem.EmissionModule wildFireEmission;
        private ParticleSystem.EmissionModule embersEmission;
        private ParticleSystem.EmissionModule fireEmission;

        public float diffusePerParticle = 0.000001f;
        public float lightUpPerParticle = 0.000000000001f;
        public float startEmissionDivider = 0.01f;

        public float timeBetweenSpawns = 5f;
        public int numberOfSpawns = 4;
        public float spawnArea = 5;
        
        private float diffuseWild;
        private float diffuseEmbers;
        private float diffuseFire;
        
        private float lightUpWild;
        private float lightUpEmbers;
        private float lightUpFire;

        private float maxWildFireEmission;
        private float maxEmbersEmission;
        private float maxFireEmission;

        private bool fireIsOut = false;
        private bool fireNotifSend = false;
        private bool isSideFire = false;
        private bool startedSpawnCoroutine = false;

        public FireSpawner fireSpawner;
        public GameObject firePrefab;

        private void Start()
        {
            var emissionWildFire = wildFire.emission;
            wildFireEmission = emissionWildFire;
            var emissionEmbers = embers.emission;
            embersEmission = emissionEmbers;
            var emissionFire = fire.emission;
            fireEmission = emissionFire;
            
            diffuseWild = emissionWildFire.rateOverTimeMultiplier * diffusePerParticle;
            diffuseEmbers = emissionEmbers.rateOverTimeMultiplier * diffusePerParticle;
            diffuseFire = emissionFire.rateOverTimeMultiplier * diffusePerParticle;
            
            lightUpWild = emissionWildFire.rateOverTimeMultiplier * lightUpPerParticle;
            lightUpEmbers = emissionEmbers.rateOverTimeMultiplier * lightUpPerParticle;
            lightUpFire = emissionFire.rateOverTimeMultiplier * lightUpPerParticle;

            maxWildFireEmission = emissionWildFire.rateOverTimeMultiplier;
            maxEmbersEmission = emissionEmbers.rateOverTimeMultiplier;
            maxFireEmission = emissionFire.rateOverTimeMultiplier;

            wildFireEmission.rateOverTimeMultiplier = startEmissionDivider;
            embersEmission.rateOverTimeMultiplier = startEmissionDivider;
            fireEmission.rateOverTimeMultiplier = startEmissionDivider;
        }

        private void Update()
        {
            if (!fireNotifSend)
            {
                fireNotifSend = true;
                EventBroker.CallEventOnFireStarted();    
            }
            
            if (DataHandler.waterParticles == 0 && !fireIsOut)
            {
                wildFireEmission.rateOverTimeMultiplier += lightUpWild;
                embersEmission.rateOverTimeMultiplier += lightUpEmbers;
                fireEmission.rateOverTimeMultiplier += lightUpFire;

                wildFireEmission.rateOverTimeMultiplier = Mathf.Clamp(wildFireEmission.rateOverTimeMultiplier, 0, maxWildFireEmission);
                embersEmission.rateOverTimeMultiplier = Mathf.Clamp(embersEmission.rateOverTimeMultiplier, 0, maxEmbersEmission);
                fireEmission.rateOverTimeMultiplier = Mathf.Clamp(fireEmission.rateOverTimeMultiplier, 0, maxFireEmission);
            }

            if (wildFireEmission.rateOverTimeMultiplier <= 0 && embersEmission.rateOverTimeMultiplier <= 0 &&
                fireEmission.rateOverTimeMultiplier <= 0)
            {
                if (fireIsOut) return;
                fireIsOut = true;
                if (isSideFire) return;
                StartCoroutine(DestroyTimer());   
            } else if (wildFireEmission.rateOverTimeMultiplier >= maxWildFireEmission && embersEmission.rateOverTimeMultiplier >= maxEmbersEmission &&
                       fireEmission.rateOverTimeMultiplier >= maxFireEmission)
            {
                if (startedSpawnCoroutine) return;
                StartCoroutine(SpawnNewFires());
                startedSpawnCoroutine = true;
            }
        }

        public void DiffuseFire()
        {
            wildFireEmission.rateOverTimeMultiplier -= diffuseWild;
            embersEmission.rateOverTimeMultiplier -= diffuseEmbers;
            fireEmission.rateOverTimeMultiplier -= diffuseFire;
        }

        IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2.5f);
            EventBroker.CallEventOnFireExtinguished();
            fireSpawner.StartCountDown();
            Destroy(gameObject);
        }

        IEnumerator SpawnNewFires()
        {
            var index = 0;
            while (index < numberOfSpawns)
            {
                yield return new WaitForSeconds(timeBetweenSpawns);
                Debug.Log("SpawningNewFire");
                // Get position on navmesh
                var spawnPosition = GetRandomPointOnNavMesh();
                // Instantiate fire on that position
                var fireInstance = Instantiate(firePrefab);
                fireInstance.transform.position = spawnPosition;
                index++;
            }
            yield return null;
        }

        private Vector3 GetRandomPointOnNavMesh()
        {
            var randomPointInSphere = UnityEngine.Random.insideUnitSphere * spawnArea;
            randomPointInSphere += transform.position;
            var finalPos = Vector3.zero;

            if (NavMesh.SamplePosition(randomPointInSphere, out var hit, spawnArea, 1))
            {
                finalPos = hit.position;
            }

            return finalPos;
        }
    }
}
