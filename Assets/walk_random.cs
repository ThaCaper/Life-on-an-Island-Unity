﻿using UnityEngine;
using UnityEngine.AI;

public class walk_random : MonoBehaviour
{

    public Transform tagret;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(tagret.position);
    }


}
