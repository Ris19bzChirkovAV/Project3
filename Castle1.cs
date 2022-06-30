using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Castle1 : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject castle_1;
    public GameObject bird;
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
                Destroy(GameObject.Find("Castle_1(Clone)"), 0.0F);
                
            }
        }
        if (destroyed)
        {
            if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) < 70.0F)
            {
                destroyed = false;
                addBirds();
                Instantiate(castle_1, new Vector3(47.33F, 2.47F, 0), Quaternion.identity);

            }
        }
        StartCoroutine(checkPosition());
    }

    public void addBirds()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < rand.Next(3,9); i++)
        {
            if (i % 2 == 0)
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(35, 60), rand.Next(7, 50), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = -1.0F;
            }
            else
            {
                var bidr = Instantiate(bird, new Vector3(rand.Next(35, 60), rand.Next(7, 50), 0), Quaternion.identity);
                bidr.GetComponent<bird1>().napravl = 1.0F;
            }
        }
    }
}
