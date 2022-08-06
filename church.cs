using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class church : MonoBehaviour
{
    public GameObject player;
    private bool go = true;

    private void Start()
    {
        player = GameObject.Find("BabaYaga");
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (go)
            {
                player.GetComponent<PlayerCtrl>().addHealth(-0.2F);
                go = false;
                StartCoroutine(wait());
            }

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        go = true;

    }
}

