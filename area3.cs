using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area3 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject area;
    public GameObject bird;
    public GameObject gold;


    private bool destroyed = false;
    void Start()
    {
        StartCoroutine(checkPosition());
    }

    IEnumerator checkPosition()
    {
        yield return new WaitForSeconds(2);
        if (!destroyed)
        {
            if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) > 70.0F)
            {
                destroyed = true;
                Destroy(GameObject.Find("area3(Clone)"), 0.0F);


            }
        }
        if (destroyed)
        {
            if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) < 70.0F)
            {
                destroyed = false;
                addBirds();
                //GameObject[] Arr = new GameObject[14];
                Instantiate(area, new Vector3(333.65F, 6.33F, 0), Quaternion.identity);


            }
        }
        StartCoroutine(checkPosition());
    }

    public void addBirds()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < 3; i++)
        {
            if (i % 2 == 0)
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(300, 360), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
                Instantiate(gold, new Vector3(rand.Next(300, 360), rand.Next(7, 30), 0), Quaternion.identity);
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(300, 360), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
                Instantiate(gold, new Vector3(rand.Next(300, 360), rand.Next(7, 30), 0), Quaternion.identity);
            }
        }
    }
}
