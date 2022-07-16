using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area5 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject wheel;
    public GameObject bird;
    public GameObject nakova;
    public GameObject table;
    public GameObject fire;
    public GameObject Chicken;

    public GameObject[] Arr = new GameObject[8];

    private bool destroyed = false;
    void Start()
    {
        StartCoroutine(checkPosition());
        Array.Resize(ref Arr, 8);
    }

    IEnumerator checkPosition()
    {
        yield return new WaitForSeconds(2);
        if (!destroyed)
        {
            if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) > 70.0F)
            {
                destroyed = true;
                foreach (GameObject G in Arr)
                {
                    if (G != null)
                        Destroy(G, 0.0F);
                }


            }
        }
        if (destroyed)
        {
            if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) < 70.0F)
            {
                destroyed = false;
                addBirds();
                //GameObject[] Arr = new GameObject[14];
                Arr[0] = Instantiate(wheel, new Vector3(457.64F, 2.12F, 0), Quaternion.identity);
                Arr[1] = Instantiate(table, new Vector3(470.95F, 0.28F, 0), Quaternion.identity);
                Arr[2] = Instantiate(nakova, new Vector3(472.85F, 0.27F, 0), Quaternion.identity);
                Arr[3] = Instantiate(fire, new Vector3(479.86F, -2.49F, 0), Quaternion.identity);
                Arr[4] = Instantiate(Chicken, new Vector3(494.96F, -0.56F, 0), Quaternion.identity);
                Arr[5] = Instantiate(Chicken, new Vector3(499.43F, -0.25F, 0), Quaternion.identity);
                Arr[6] = Instantiate(Chicken, new Vector3(503.09F, -0.37F, 0), Quaternion.identity);
                Arr[7] = Instantiate(Chicken, new Vector3(508.04F, -0.41F, 0), Quaternion.identity);


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
                var bidr = Instantiate(bird, new Vector3(rand.Next(450, 510), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(450, 510), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
            }
        }
    }
}
