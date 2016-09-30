﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	public Text countText;
	public Text winText;

	private Rigidbody rb;

	private int count;

	void Start ()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Pick Up"))
			{
				other.gameObject.SetActive(false);
				count++;
				SetCountText ();
			}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) 
		{
			winText.text = "You Win!!!!";
		}
	}
}