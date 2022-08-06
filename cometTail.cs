using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometTail : MonoBehaviour
{
    private float x = 0.03F, y = 0.03F;
    void Update()
    {
        transform.localScale = new Vector3(x, y, 1);
        x -= 0.001F;
        y -= 0.001F;
        if (x < 0.001F)
            Destroy(gameObject);
    }
}
