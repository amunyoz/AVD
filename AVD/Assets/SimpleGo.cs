using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleGo : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public Transform Destination;
    Vector3 PreviousPosition;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Destination.transform.position;
    }
    private void Update()
    {
        if (Destination.transform.position != PreviousPosition) {
            agent.destination = Destination.transform.position;
            PreviousPosition = Destination.transform.position;
        }
        
    }
}


