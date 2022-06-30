using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(startPosition.x - transform.position.x) > 1.5F || Mathf.Abs(startPosition.y - transform.position.y) > 1.5F)
            Destroy(gameObject);
    }
}
