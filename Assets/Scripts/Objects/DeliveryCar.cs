using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeliveryCar : BusinessUnit, IClickable
{
    [HideInInspector] public Transform[] targets;
    float stoppingDistance = 1f;
    NavMeshAgent agent;
    int currentTargetId = 0;

    public void OnClick()
    {
        (GameManager.Instance.representationManager.buildingsRepresentation as MapRepresentation).DeselectAll();
        Select();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdateTargets", 0f, 3f);
        naming = GameManager.Instance.datManager.GetRandomName();
        desc = GameManager.Instance.datManager.GetDriverDesc();
    }

    // Update is called once per frame
    void UpdateTargets()
    {
        float currentDist = Vector3.Distance(transform.position, targets[currentTargetId].position);
        if (currentDist <= stoppingDistance && agent.destination != null)
        {
            currentTargetId = (currentTargetId + 1) % targets.Length;
            if (agent.gameObject.activeInHierarchy)
                agent.destination = targets[currentTargetId].position;
        }
        else
        {
            if (agent.gameObject.activeInHierarchy)
                agent.destination = targets[currentTargetId].position;
        }
    }
}
