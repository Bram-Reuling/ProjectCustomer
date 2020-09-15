using System;
using System.Collections;
using ProjectCustomer.Core;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace ProjectCustomer.Animals
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimalMovement : MonoBehaviour, IInteractable
    {
        public AnimatorController aliveAnim;
        public AnimatorController deadAnim;
        public int randomPointDistance;

        public BoxCollider deadBoxCollider;
        public BoxCollider aliveCollider;
        
        private NavMeshAgent agent;
        private Animator animator;

        private bool isAlive;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            isAlive = true;
        }

        private void Start()
        {
            animator.runtimeAnimatorController = aliveAnim;
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
            while (isAlive)
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

        public void Interacted()
        {
            if (!isAlive)
            {
                Debug.Log("YES");   
            }
        }

        public void Death()
        {
            isAlive = false;
            StopCoroutine(SetRandomDestination());
            agent.isStopped = true;
            agent.ResetPath();
            animator.runtimeAnimatorController = deadAnim;
            deadBoxCollider.enabled = true;
            aliveCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Collision");
            if (isAlive && other.gameObject.CompareTag("Fire"))
            {
                Debug.Log("HIT");
                StopCoroutine(SetRandomDestination());
                agent.ResetPath();
            }
        }
    }
}
