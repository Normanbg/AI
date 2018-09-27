using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

    private float distance = 0.0f;
    private float distanceX = 0.0f;
    private float distanceZ = 0.0f;
    Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 8: calculate the distance. If we are in min_distance radius, we stop moving
        // Otherwise devide the result by time_to_target (0.25 feels good)
        // Then call move.SetMovementVelocity()
        distanceX = (move.transform.position.x - move.target.transform.position.x);
        distanceZ = (move.transform.position.z - move.target.transform.position.z);
        distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceZ, 2));

        if (distance < min_distance)
        {
            // Inside the slowing area
            move.mov_velocity = move.mov_velocity.normalized * move.max_mov_velocity * (distance / min_distance);
        }
        else
        {
            // Outside the slowing area.
            move.mov_velocity = (move.mov_velocity.normalized * move.max_mov_velocity) / time_to_target;
        }
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
