using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float stoppingDistanceFromThePlayer = 1f;
    [SerializeField] private float randomWalkRadius = 5f;
    [SerializeField] private float lookRadius = 10f;

    private bool canAttack = true;

    Transform target;
    NavMeshAgent agent;
    EnemyController controller; 

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<EnemyController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance < stoppingDistanceFromThePlayer)
        {
            FaceTarget();
            stopEnemy();

            if (canAttack)
            {
                controller.attack(); 
                StartCoroutine(waitForNextAttack());
            }
        }
        else if (distance <= lookRadius)
        {
            goToTarget();
        }
        else if (!agent.hasPath && distance > lookRadius)
        {
            agent.SetDestination(getPoint.Instance.GetRandomPoint(transform, randomWalkRadius)); 
        } 
    }

    private void goToTarget()
    {
        agent.isStopped = false; 
        agent.SetDestination(target.transform.position);
    }

    private void stopEnemy()
    {
        agent.isStopped = true; 
    }

    private IEnumerator waitForNextAttack()
    {
        canAttack = false;

        yield return new WaitForSeconds(1);

        canAttack = true; 
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }
    
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
