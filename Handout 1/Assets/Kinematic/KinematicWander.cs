using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        float x = RandomBinominal();
        float z = RandomBinominal();
        //move.mov_velocity = (RandomBinominal(), RandomBinominal());
        move.mov_velocity.x = x;
        move.mov_velocity.z = z;

        move.mov_velocity = move.mov_velocity.normalized * move.max_mov_velocity;
    }

}
