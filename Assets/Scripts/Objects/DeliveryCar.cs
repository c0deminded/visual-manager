using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeliveryCar : MonoBehaviour
{
    [HideInInspector] public Transform[] targets;
    float stoppingDistance = 1f;
    NavMeshAgent agent;
    int currentTargetId = 0;
    Coroutine cor;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cor = StartCoroutine(UpdateTargets());
    }

    // Update is called once per frame
    IEnumerator UpdateTargets()
    {
        while (true)
        {
            float currentDist = Vector3.Distance(transform.position, targets[currentTargetId].position);
            //Debug.Log(currentDist + "//" +  stoppingDistance);
            //Debug.Log(currentDist <= stoppingDistance && agent.destination != null);
            if (currentDist <= stoppingDistance && agent.destination != null)
            {
                currentTargetId = (currentTargetId + 1) % targets.Length;
                agent.destination = targets[currentTargetId].position;
            }
            else
            {
                if (agent.gameObject.activeInHierarchy)
                    agent.destination = targets[currentTargetId].position;
            }
            yield return new WaitForSeconds(3f);
            if (!agent.gameObject.activeInHierarchy)
                yield return null;
        }
    }
}
