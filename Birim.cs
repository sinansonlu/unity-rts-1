using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Birim : MonoBehaviour
{
    private NavMeshAgent agent;

    public float can;
    public float saldiri;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void Yuru(Vector3 konum)
    {
        agent.SetDestination(konum);
    }

    public void AgentBelirle()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
