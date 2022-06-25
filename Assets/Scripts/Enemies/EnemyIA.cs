using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float stoppingDistanceFromThePlayer = 2000f;
    [SerializeField] private float randomWalkRadius = 5f;
    [SerializeField] private float lookRadius = 10f;

    private bool canAttack = true;
    private Animator _animator;


    Transform target;
    NavMeshAgent agent;
    EnemyController controller; 

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<EnemyController>();
        _animator = GetComponent<Animator>(); 
        //TryGetComponent(out _animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_animator.GetBool("isDead"))
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            Debug.Log(distance);
            if (distance < stoppingDistanceFromThePlayer)
            {
                FaceTarget();
                stopEnemy();
                _animator.SetBool("Moving", false);

                if (canAttack)
                {
                    controller.attack();
                    StartCoroutine(waitForNextAttack());
                }
            }
            else if (distance <= lookRadius)
            {
                goToTarget();
                _animator.SetBool("Moving", true);
            }
            else if (!agent.hasPath && distance > lookRadius)
            {
                _animator.SetBool("Moving", true);
                agent.SetDestination(getPoint.Instance.GetRandomPoint(transform, randomWalkRadius));
            }
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
