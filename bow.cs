using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{

    public GameObject arrow;
    public GameObject bowArrow;
    public GameObject player;
    public SpriteRenderer sr;
    private bool attack = false;
    private void Start()
    {
        player = GameObject.Find("BabaYaga");
        System.Random rand = new System.Random();
        StartCoroutine(waitAttack());
    }
    void FixedUpdate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 180);
        if (attack)
        {
            attack = false;
            var N = Instantiate(arrow, bowArrow.transform.position, Quaternion.identity);
            N.GetComponent<arrow>().Add(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            
        }
    }

    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(2);
        attack = true;
        StartCoroutine(waitAttack());
    }
}
