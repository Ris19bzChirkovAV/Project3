using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb2 : MonoBehaviour
{
    private float mulX;
    private float mulY;
    public GameObject bombAnim;
    public GameObject gold;
    public GameObject gold10;
    private float boomRadius;

    //PlayerPrefs.GetInt("l1Stars") < 2)
    //PlayerPrefs.SetInt("l1Stars", 2);

    private void Start()
    {
        boomRadius = PlayerPrefs.GetFloat("Bomb2Radius");
        Debug.Log(boomRadius);
    }
    public void goBoom()
    {
        StartCoroutine(Boom());
    }
    public IEnumerator Boom()
    {
        yield return new WaitForSeconds(3);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
        foreach (Collider2D C in colliders)
        {
            if (C.tag == "Kamen")
            {
                mulX = transform.position.x - C.gameObject.transform.position.x;
                mulY = transform.position.y - C.gameObject.transform.position.y;
                //  C.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                C.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(mulX * -300, mulY * -300, 0));
                // Destroy(C.gameObject, 0.0F);
            }

            if (C.tag == "Doska")
            {
                mulX = transform.position.x - C.gameObject.transform.position.x;
                mulY = transform.position.y - C.gameObject.transform.position.y;
                C.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                C.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                C.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(mulX * -300, mulY * -300, 0));
            }

            if (C.tag == "Window")
            {
                Instantiate(gold10, new Vector3(C.transform.position.x, C.transform.position.y, 0), Quaternion.identity);
                Destroy(C.gameObject);
            }

            if (C.tag == "krest")
            {
                C.gameObject.GetComponent<Kamen>().addzombie();
                Instantiate(gold, new Vector3(C.transform.position.x, C.transform.position.y, 0), Quaternion.identity);
                Destroy(C.gameObject);
            }

            if (C.tag == "Defence")
            {
                mulX = transform.position.x - C.gameObject.transform.position.x;
                mulY = transform.position.y - C.gameObject.transform.position.y;
                C.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                C.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(mulX * -300, mulY * -300, 0));
            }
        }
        Instantiate(bombAnim, new Vector3(transform.position.x, transform.position.y + 0.5F, 0), Quaternion.identity);
        Destroy(gameObject, 0.0F);
    }
}
