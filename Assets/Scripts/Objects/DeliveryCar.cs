using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeliveryCar : MonoBehaviour
{
    [HideInInspector] public Transform[] targets;
    float stoppingDistance = 0.5f;
    NavMeshAgent agent;
    int currentTargetId = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdateTargets", 0f, 3f);
    }

    // Update is called once per frame
    void UpdateTargets()
    {
        float currentDist = Vector3.Distance(transform.position, targets[currentTargetId].position);
        Debug.Log(currentDist + "//" +  stoppingDistance);
        Debug.Log(currentDist <= stoppingDistance && agent.destination != null);
        if (currentDist <= stoppingDistance && agent.destination != null)
        {
            currentTargetId = (currentTargetId+1)%3;
            agent.destination = targets[currentTargetId].position;
        }
        else
        {
            agent.destination = targets[currentTargetId].position;
        }
    }
}
