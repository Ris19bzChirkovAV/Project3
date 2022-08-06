using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamen : MonoBehaviour
{
    public GameObject player;
    public GameObject explosiveAnim;
    public GameObject gold;
    public GameObject zombie;
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
        Instantiate(explosiveAnim, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Instantiate(gold, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    public void addzombie()
    {
        Instantiate(zombie, new Vector3(transform.position.x, transform.position.y - 1.5F, 0), Quaternion.identity);
    }

    IEnumerator changeGravity()
    {
        yield return new WaitForSeconds(2);
        rb.gravityScale = 1.0F;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (rb.velocity.magnitude - 1.0F > player.GetComponent<Rigidbody2D>().velocity.magnitude)
            {
                player.GetComponent<PlayerCtrl>().addHealth(-0.1F);
                destroy();
            }
        }
    }
}
