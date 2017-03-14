using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLevel2 : MonoBehaviour {

	public int health = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{

		health -= 1; // health -= 1 is the same as saying health = health - 1
		Debug.Log(health);

		if(health == 0) {
			gameObject.SetActive(false);
			FindObjectOfType<BallLevel2>().YouBrokeABrick();
		}

	}
}
