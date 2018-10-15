using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AssignTargetPos : MonoBehaviour {
    public GameObject target;
    NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (navMeshAgent != null && target != null)
        {
           navMeshAgent.destination = target.transform.position;
        }
	}
}
