using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public GameObject rain;
    public GameObject playerPosition;
    System.Random rand = new System.Random();
    private bool oneOn = false;


    private void FixedUpdate()
    {
        if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) < 40.0F && !oneOn)
        {
            Debug.Log("on");
            StartCoroutine(goRain());
            oneOn = true;
        }
        if (Mathf.Abs(playerPosition.transform.position.x - transform.position.x) > 40.0F && oneOn)
        {
            Debug.Log("off");
            oneOn = false;
        }
    }
    public IEnumerator goRain()
    {
        yield return new WaitForSeconds(0.05F);
        Instantiate(rain, new Vector3((float)rand.Next(-103, -90), transform.position.y, 0), Quaternion.identity);
        if (oneOn)
            StartCoroutine(goRain());
    }
}
