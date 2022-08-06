using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comet : MonoBehaviour
{
    public GameObject tail;
    Rigidbody2D rb;
    public float fin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Instantiate(tail, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if (transform.position.y < fin)
            Destroy(gameObject);
    }

    public void Go(float _x, float _y)
    {
        StartCoroutine(Go1(_x, _y));
    }

    IEnumerator Go1(float _x, float _y)
    {
        yield return new WaitForSeconds(0.1F);
        rb.AddForce(new Vector3(_x, _y, 0), ForceMode2D.Impulse);
    }
}
