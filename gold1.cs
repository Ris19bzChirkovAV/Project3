using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold1 : MonoBehaviour
{
    public GameObject gold;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
        rb.AddForce(new Vector3(0, 5.0F, 0), ForceMode2D.Impulse);
        
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.8F);
        Instantiate(gold, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(gameObject);
    }

}
