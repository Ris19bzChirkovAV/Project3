using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj1 : MonoBehaviour
{

    [SerializeField] float time;
    void Start()
    {
        Destroy(gameObject, time);
    }


}
