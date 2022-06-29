using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamen : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    float currentSpeed;
    float oldSpeed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(changeGravity());
        player = GameObject.Find("BabaYaga");
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
        if (currentSpeed < oldSpeed - 2.0F)
            destroy();
        oldSpeed = currentSpeed;
    }

    public void destroy()
    {
        player.GetComponent<PlayerCtrl>().addHealth(0.1F);
        Destroy(gameObject);
    }

    IEnumerator changeGravity()
    {
        yield return new WaitForSeconds(2);
        rb.gravityScale = 1.0F;
    }
}
