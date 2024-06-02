using UnityEngine;
using UnityEngine.AI;

public class Roaming : MonoBehaviour
{
    public float wanderRange = 10f; // ????
    private NavMeshAgent navMeshAgent; // NavMeshAgent ??????????
    private Vector3 randomDestination; // ????????

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent ????????????????????");
            return;
        }

        SetRandomDestination();
    }

    private void Update()
    {
        // ??????????????????????????????
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        // ??????????
        Vector3 randomDirection = Random.insideUnitSphere * wanderRange;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, wanderRange, -1);
        randomDestination = navHit.position;

        // NavMesh ??????????????????
        navMeshAgent.SetDestination(randomDestination);
    }
}