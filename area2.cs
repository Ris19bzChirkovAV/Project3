using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area2 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject defense;
    public GameObject kareta;
    public GameObject pig;
    public GameObject bird;
    public GameObject[] Arr = new GameObject[15];
    public GameObject gold;

    private bool destroyed = false;
    void Start()
    {
        StartCoroutine(checkPosition());
        Array.Resize(ref Arr, 15);
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
                Arr[0] = Instantiate(defense, new Vector3(228.84F, 0.84F, 0), Quaternion.identity);
                Arr[1] = Instantiate(defense, new Vector3(229.57F, 0.67F, 0), Quaternion.identity);
                Arr[2] = Instantiate(defense, new Vector3(230.33F, 0.55F, 0), Quaternion.identity);
                Arr[3] = Instantiate(defense, new Vector3(231.1F, 0.43F, 0), Quaternion.identity);
                Arr[4] = Instantiate(defense, new Vector3(231.83F, 0.33F, 0), Quaternion.identity);
                Arr[5] = Instantiate(defense, new Vector3(232.59F, 0.19F, 0), Quaternion.identity);
                Arr[6] = Instantiate(defense, new Vector3(233.32F, 0.05F, 0), Quaternion.identity);
                Arr[7] = Instantiate(defense, new Vector3(234.04F, -0.06F, 0), Quaternion.identity);
                Arr[8] = Instantiate(defense, new Vector3(234.77F, -0.18F, 0), Quaternion.identity);
                Arr[9] = Instantiate(defense, new Vector3(235.5F, -0.3F, 0), Quaternion.identity);
                Arr[10] = Instantiate(defense, new Vector3(236.24F, -0.46F, 0), Quaternion.identity);
                Arr[11] = Instantiate(defense, new Vector3(236.99F, -0.56F, 0), Quaternion.identity);
                Arr[12] = Instantiate(defense, new Vector3(237.75F, -0.7F, 0), Quaternion.identity);
                Arr[13] = Instantiate(pig, new Vector3(265.97F, 2.3F, 0), Quaternion.identity);
                Arr[14] = Instantiate(kareta, new Vector3(287.32F, 7.35F, 0), Quaternion.identity);

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
                var bidr = Instantiate(bird, new Vector3(rand.Next(230, 290), rand.Next(7, 50), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
                Instantiate(gold, new Vector3(rand.Next(230, 290), rand.Next(7, 50), 0), Quaternion.identity);
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(230, 290), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
                Instantiate(gold, new Vector3(rand.Next(230, 290), rand.Next(7, 50), 0), Quaternion.identity);
            }
        }
    }
}
