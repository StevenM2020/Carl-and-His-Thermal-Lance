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
        if(Vector3.Distance(transform.position, target) < 6)
        {
            IterateWaypointIndex();
            UpdateDestination();
            Debug.Log("update");
        }
        else if (spotted.canSeePlayer)
        {
          target = player.transform.position;
          agent.speed = 300;
          agent.acceleration = 300;
          agent.SetDestination(target);
            Debug.Log("me1");
        }
        
        if (!spotted.canSeePlayer)
        {
            agent.speed = agentSpeed;
            agent.acceleration = agentAcceleration;
            Debug.Log(Vector3.Distance(transform.position, target));
        }
        else
        {
            UpdateDestination();
            Debug.Log("me3");
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
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }


}
