using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 2)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex ==  waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
