using UnityEngine;
using System.Collections;

public class KinematicFaceMovement : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
        // TODO 7: rotate the whole tank to look in the movement direction
        // Extremnely similar to TODO 2
        float rad = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
        move.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * rad, Vector3.up);

    }
}
