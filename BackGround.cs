using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{

	private float multiplier;
	private float multiplierY;
    private GameObject Player;

	void Start()
	{
		Player = GameObject.Find("BabaYaga");
	}

	void Update()
	{
		multiplier = (Player.transform.position.x - 230) / 40;
		multiplierY = (Player.transform.position.y - 40) / 5;
		transform.position = new Vector3(Player.transform.position.x - multiplier, Player.transform.position.y - multiplierY, 0);
		if (Input.GetKey("escape"))
		{
			Player.GetComponent<PlayerCtrl>().menuLevel();
			SceneManager.LoadScene("menu");
			this.enabled = false;
		}
	}
}
