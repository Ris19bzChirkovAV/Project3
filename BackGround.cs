using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField] float speed;
	private Vector3 PlayerPosition;
	private float multiplier;
	//	private float multiplierY = 0;
	private Vector3 nextPosition;
	private GameObject Player;

	void Start()
	{
		Player = GameObject.Find("BabaYaga");
	}

	void Update()
	{
		multiplier = (Player.transform.position.x - 155) / 12;
		transform.position = new Vector3(Player.transform.position.x - multiplier, 15, 0);
		//Debug.Log(multiplier);
		if (Input.GetKey("escape"))
			Application.Quit();
	}
}
