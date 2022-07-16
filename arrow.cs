using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody2D rb;
    private bool rotate = false;
    private bool start = false;
    float x;
    float y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(x, y, 0), ForceMode2D.Impulse);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotate)
            transform.right = rb.velocity.normalized;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (start)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerCtrl>().addHealth(-0.3F);
            }
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
            rotate = true;
            transform.parent = collision.gameObject.transform;
            StartCoroutine(death());
        }
    }

    public void Add(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
