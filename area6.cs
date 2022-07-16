using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area6 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject krest;
    public GameObject bird;
    public GameObject[] Arr = new GameObject[9];
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
                Arr[0] = Instantiate(krest, new Vector3(405.27F, 3.98F, 0), Quaternion.identity);
                Arr[1] = Instantiate(krest, new Vector3(410.57F, 4.87F, 0), Quaternion.identity);
                Arr[2] = Instantiate(krest, new Vector3(413.26F, 5.39F, 0), Quaternion.identity);
                Arr[3] = Instantiate(krest, new Vector3(416.0F, 5.7F, 0), Quaternion.identity);
                Arr[4] = Instantiate(krest, new Vector3(418.89F, 5.75F, 0), Quaternion.identity);
                Arr[5] = Instantiate(krest, new Vector3(421.71F, 5.86F, 0), Quaternion.identity);
                Arr[6] = Instantiate(krest, new Vector3(424.41F, 5.99F, 0), Quaternion.identity);
                Arr[7] = Instantiate(krest, new Vector3(427.31F, 6.06F, 0), Quaternion.identity);
                Arr[8] = Instantiate(krest, new Vector3(430.47F, 5.75F, 0), Quaternion.identity);



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
                var bidr = Instantiate(bird, new Vector3(rand.Next(400, 450), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(400, 450), rand.Next(7, 30), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
            }
        }
    }
}
