﻿using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 8: calculate the distance. If we are in min_distance radius, we stop moving
        Vector3 distance = move.target.transform.position - move.transform.position;
        if(distance.magnitude<=min_distance)
        {
            move.mov_velocity = Vector3.zero;
        }
        if(distance.magnitude<=1.5f)
        {
            Vector3 vel = move.mov_velocity*time_to_target;
            move.SetMovementVelocity(vel);
        }
        // Otherwise devide the result by time_to_target (0.25 feels good)
        // Then call move.SetMovementVelocity()
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
