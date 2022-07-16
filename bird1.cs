using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird1 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator an;
    public GameObject player;
    public float napravl = 1.0F;
    private bool death = false;

    void Start()
    {
        an = GetComponent<Animator>();
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
        if (!death)
            rb.velocity = new Vector3(2.5F * napravl, 0, 0);
    }

    IEnumerator DelBird()
    {
        yield return new WaitForSeconds(4);
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 50.0F)
            Destroy(gameObject);
        StartCoroutine(DelBird());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BabaYaga" || collision.gameObject.name == "arrow2(Clone)")
        {
            death = true;
            an.enabled = false;
            rb.gravityScale = 1.0F;
            Destroy(gameObject, 4.0F);
        }
    }
}
