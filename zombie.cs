using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    private bool go = false;

    void Start()
    {
        player = GameObject.Find("BabaYaga");
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        StartCoroutine(wait());
        
    }
    void FixedUpdate()
    {
        if (!go)
        {
            rb.velocity = new Vector3(0, 1, 0);
        }
        if (go)
        {
            rb.velocity = new Vector3(-0.5F, rb.velocity.y, 0);
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 70.0F)
            Destroy(gameObject);

    }

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(2);
        go = true;
        cc.isTrigger = false;
    }
}
