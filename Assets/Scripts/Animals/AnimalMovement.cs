using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace ProjectCustomer.Animals
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimalMovement : MonoBehaviour
    {
        public int randomPointDistance;
        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            StartCoroutine(SetRandomDestination());
        }

        private Vector3 GetRandomPositionOnNavMesh()
        {
            var randomPointInSphere = Random.insideUnitSphere * randomPointDistance;
            randomPointInSphere += transform.position;
            var finalPos = Vector3.zero;

            if (NavMesh.SamplePosition(randomPointInSphere, out var hit, randomPointDistance, 1))
            {
                finalPos = hit.position;
            }

            return finalPos;
        }

        private IEnumerator SetRandomDestination()
        {
            while (true)
            {
                agent.SetDestination(GetRandomPositionOnNavMesh());
                yield return new WaitUntil(() => !AgentCompletedPath());
            }
        }

        private bool AgentCompletedPath()
        {
            return agent.hasPath;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, randomPointDistance);
        }
    }
}
