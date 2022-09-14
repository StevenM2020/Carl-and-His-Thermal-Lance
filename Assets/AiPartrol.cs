using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPartrol : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public GameObject player;

    public FieldOfView spotted;

    float agentSpeed;
    float agentAcceleration;

    bool foundPlayer;


    // Start is called before the first frame update
    void Start()
    {
        foundPlayer = false;
        agent = GetComponent<NavMeshAgent>();
        agentSpeed = agent.speed;
        agentAcceleration = agent.acceleration;
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        else if (spotted.canSeePlayer)
        {
          target = player.transform.position;
          agent.speed = 300;
          agent.acceleration = 300;
          agent.SetDestination(target);
        }
        else if (!spotted.canSeePlayer)
        {
            agent.speed = agentSpeed;
            agent.acceleration = agentAcceleration;
        }
        else
            UpdateDestination();

        if (foundPlayer)
            Debug.Log("OOF");



    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }


}
