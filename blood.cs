using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blood : MonoBehaviour
{
    public Image img;
    public float a = 1.0F;
    void Start()
    {
        img.color = new Vector4(1, 1, 1, 0);
        this.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (img.color.a > 0)
        {
            img.color = new Vector4(1, 1, 1, a);
            a -= 0.01F;
        }
        else
            this.enabled = false;
    }

    public void go()
    {
        this.enabled = true;
        a = 1.0F;
        img.color = new Vector4(1, 1, 1, 1);

    }
}
