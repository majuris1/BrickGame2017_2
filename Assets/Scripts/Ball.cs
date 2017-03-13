﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public Vector2 startingVelocity = new Vector2(15, -20);
	private Vector3 startingPosition;
	public GameObject gameOverSign;
	public GameObject youwinSign;
	public UnityEngine.UI.Text livesValue;
	public UnityEngine.UI.Text pointsValue;

	int lives = 3;
	int points = 0;

	void Start () {
		startingPosition = transform.position;
		GetComponent<Rigidbody2D>().velocity = startingVelocity;
		livesValue.text = lives.ToString();
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
		livesValue.text = lives.ToString();

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
		points += 1;
		pointsValue.text = points.ToString();

		var bricksleft = FindObjectsOfType<Brick>().Length;
		if(bricksleft == 0) {
			youwinSign.SetActive(true);
		}
	}
}
