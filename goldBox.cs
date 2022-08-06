using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldBox : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    Rigidbody2D rb;
    [SerializeField] float speed;
    public bool up = false;
    public bool go = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("targetGold");
        player = GameObject.Find("BabaYaga");
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            speed += 0.5F;
            
            if (Mathf.Abs(transform.position.x - target.transform.position.x) < 0.2F)
            {
                player.GetComponent<PlayerCtrl>().addGold(100);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "bombVzriv(Clone)")
        {
            up = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, 10.0F, 0), ForceMode2D.Impulse);
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        rb.isKinematic = true;
        rb.velocity = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(0.25F, 0.25F, 0);
        go = true;
    }
}
