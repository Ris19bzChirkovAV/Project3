using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area4 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject defense;
    public GameObject bird;
    public GameObject[] Arr = new GameObject[9];
    public GameObject gold;

    private bool destroyed = false;
    void Start()
    {
        StartCoroutine(checkPosition());
        Array.Resize(ref Arr, 9);
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
                Arr[0] = Instantiate(defense, new Vector3(386.61F, 0.81F, 0), Quaternion.identity);
                Arr[1] = Instantiate(defense, new Vector3(387.38F, 1.01F, 0), Quaternion.identity);
                Arr[2] = Instantiate(defense, new Vector3(388.14F, 1.15F, 0), Quaternion.identity);
                Arr[3] = Instantiate(defense, new Vector3(388.93F, 1.3F, 0), Quaternion.identity);
                Arr[4] = Instantiate(defense, new Vector3(389.72F, 1.52F, 0), Quaternion.identity);
                Arr[5] = Instantiate(defense, new Vector3(390.53F, 1.67F, 0), Quaternion.identity);
                Arr[6] = Instantiate(defense, new Vector3(391.33F, 1.79F, 0), Quaternion.identity);
                Arr[7] = Instantiate(defense, new Vector3(392.18F, 1.96F, 0), Quaternion.identity);
                Arr[8] = Instantiate(defense, new Vector3(392.97F, 2.05F, 0), Quaternion.identity);

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
                var bidr = Instantiate(bird, new Vector3(rand.Next(360, 410), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
                Instantiate(gold, new Vector3(rand.Next(360, 410), rand.Next(7, 30), 0), Quaternion.identity);
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(360, 410), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
                Instantiate(gold, new Vector3(rand.Next(360, 410), rand.Next(7, 30), 0), Quaternion.identity);
            }
        }
    }
}
