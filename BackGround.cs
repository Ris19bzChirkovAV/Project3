using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

	private float multiplier;
	private GameObject Player;

	void Start()
	{
		Player = GameObject.Find("BabaYaga");
	}

	void Update()
	{
		multiplier = (Player.transform.position.x - 230) / 40;
		transform.position = new Vector3(Player.transform.position.x - multiplier, 15, 0);
		//Debug.Log(multiplier);
		if (Input.GetKey("escape"))
			Application.Quit();
	}
}
