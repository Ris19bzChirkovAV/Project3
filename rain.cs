using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(fin());
    }

    IEnumerator fin()
    {
        yield return new WaitForSeconds(2.5F);
        Destroy(gameObject);
    }
}
