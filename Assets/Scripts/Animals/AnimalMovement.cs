using System;
using System.Collections;
using System.Collections.Generic;
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

        public GameObject[] deSpawns;
        
        private NavMeshAgent agent;
        private Animator animator;

        private bool isAlive;
        public bool isRevived;

        private Vector3 endPos;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            isAlive = true;
            isRevived = false;
            endPos = Vector3.zero;
        }

        private void Start()
        {
            animator.runtimeAnimatorController = aliveAnim;
            deSpawns = GameObject.FindGameObjectsWithTag("DeSpawn");
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
            EventBroker.CallEventOnFoxRevive();
            
            if (!isAlive && !isRevived)
            {
                isRevived = true;

                foreach (var deSpawn in deSpawns)
                {
                    var distance = Vector3.Distance(transform.position, deSpawn.transform.position);
                    Debug.Log(distance);

                    if (endPos == Vector3.zero)
                    {
                        Debug.Log("YEET");
                        endPos = deSpawn.transform.position;
                    }
                    else if (Vector3.Distance(transform.position, endPos) < distance)
                    {
                        Debug.Log("YEET2");
                        endPos = deSpawn.transform.position;
                    }
                }
                
                Debug.Log("First" + endPos);
                
                if (NavMesh.SamplePosition(endPos, out var hit, randomPointDistance, 1))
                {
                    endPos = hit.position;
                }
                
                Debug.Log("Second" + endPos);
                
                animator.runtimeAnimatorController = aliveAnim;
                deadBoxCollider.enabled = false;
                aliveCollider.enabled = true;
                agent.ResetPath();
                agent.SetDestination(endPos);
                
                Debug.Log("Last" + agent.destination);
            }
        }

        public void Death()
        {
            isAlive = false;
            StopCoroutine(SetRandomDestination());
            agent.SetDestination(transform.position);
            animator.runtimeAnimatorController = deadAnim;
            deadBoxCollider.enabled = true;
            aliveCollider.enabled = true;
        }

        public void DeSpawn()
        {
            Destroy(gameObject);
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
