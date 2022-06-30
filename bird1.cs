using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird1 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public GameObject player;
    public float napravl = 1.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("BabaYaga");
        StartCoroutine(DelBird());
    }

    void FixedUpdate()
    {
        if (rb.velocity.x > 0)
            sr.flipX = true;
        else
            sr.flipX = false;
        rb.velocity = new Vector3(2.5F * napravl, 0, 0);
    }

    IEnumerator DelBird()
    {
        yield return new WaitForSeconds(4);
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 50.0F)
            Destroy(gameObject);
        StartCoroutine(DelBird());
    }
}
