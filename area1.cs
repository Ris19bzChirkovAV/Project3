using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area1 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject defense;
    public GameObject kareta;
    public GameObject chicken;
    public GameObject bird;
    public GameObject[] Arr = new GameObject[15];
    
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
                Arr[0] = Instantiate(defense, new Vector3(75.41F, -0.73F, 0), Quaternion.identity);
                Arr[1] = Instantiate(defense, new Vector3(76.16596F, -0.701F, 0), Quaternion.identity);
                Arr[2] = Instantiate(defense, new Vector3(76.902F, -0.68F, 0), Quaternion.identity);
                Arr[3] = Instantiate(defense, new Vector3(77.66F, -0.66F, 0), Quaternion.identity);
                Arr[4] = Instantiate(defense, new Vector3(78.37F, -0.66F, 0), Quaternion.identity);
                Arr[5] = Instantiate(defense, new Vector3(79.13F, -0.66F, 0), Quaternion.identity);
                Arr[6] = Instantiate(defense, new Vector3(79.92F, -0.68F, 0), Quaternion.identity);
                Arr[7] = Instantiate(defense, new Vector3(80.69F, -0.68F, 0), Quaternion.identity);
                Arr[8] = Instantiate(defense, new Vector3(81.42F, -0.70F, 0), Quaternion.identity);
                Arr[9] = Instantiate(defense, new Vector3(82.14F, -0.70F, 0), Quaternion.identity);
                Arr[10] = Instantiate(defense, new Vector3(82.9F, -0.73F, 0), Quaternion.identity);
                Arr[11] = Instantiate(defense, new Vector3(83.65F, -0.77F, 0), Quaternion.identity);
                Arr[12] = Instantiate(chicken, new Vector3(97.51F, -1.82F, 0), Quaternion.identity);
                Arr[13] = Instantiate(kareta, new Vector3(110.58F, 7.12F, 0), Quaternion.identity);
                Arr[14] = Instantiate(chicken, new Vector3(91.51F, -1.82F, 0), Quaternion.identity);

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
                var bidr = Instantiate(bird, new Vector3(rand.Next(90, 150), rand.Next(7, 50), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(90, 150), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
            }
        }
    }
}
