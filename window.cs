using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 startPosition;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - startPosition.x) > 0.5F || Mathf.Abs(transform.position.y - startPosition.y) > 0.7F)
        {
            sr.color = new Vector4(0.11F, 0.11F, 0.2F,1);
            this.enabled = false;
        }
    }
}
