using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public GameObject goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null && goal != null)
        {
            agent.SetDestination(goal.transform.position);
        }
    }
}