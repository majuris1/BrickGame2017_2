using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector2 startingVelocity = new Vector2(15, -20);
	private Vector3 startingPosition;
	public GameObject gameOverSign;
	public GameObject youwinSign;

	int lives = 3;

	void Start () {
		startingPosition = transform.position;
		GetComponent<Rigidbody2D>().velocity = startingVelocity;
	}


	void Update () {
		if(transform.position.y < -4.0f) {
			GetOut();
		}
		if(Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody2D>().velocity = startingVelocity;
		}
	}

	void GetOut()
	{
		Debug.Log("You are out");
		lives = lives - 1;

		transform.position = startingPosition;
		GetComponent<Rigidbody2D>().velocity = new Vector2();


		if(lives == 0) {
			DoGameOver();
		}
	}

	void DoGameOver()
	{
		gameOverSign.SetActive(true);
	}

	public void YouBrokeABrick()
	{
		var bricksleft = FindObjectsOfType<Brick>().Length;
		if(bricksleft == 0) {
			youwinSign.SetActive(true);
		}
	}
}
