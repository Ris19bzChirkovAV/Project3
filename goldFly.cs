using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldFly : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    [SerializeField] float speed;
    void Start()
    {
        target = GameObject.Find("targetGold");
        player = GameObject.Find("BabaYaga");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - target.transform.position.x) < 0.2F)
        {
            
            player.GetComponent<PlayerCtrl>().addGold(1);
            Destroy(gameObject);
        }
        speed += 0.1F;
    }

}
