using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public GameObject player;
    public float napravl = 1.0F;
    System.Random rand = new System.Random();
    private Animator animator;
    private bool OnStop = false;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("BabaYaga");
        animator = GetComponent<Animator>();
        StartCoroutine(ChandeNapravl());
    }

    void FixedUpdate()
    {
        if (rb.velocity.x > 0)
            sr.flipX = true;
        else
            sr.flipX = false;
        if(!OnStop)
            rb.velocity = new Vector3(0.9F * napravl, rb.velocity.y, 0);
    }

    IEnumerator ChandeNapravl()
    {
        if (!OnStop)
            State = CharState.chicken1;
        yield return new WaitForSeconds(rand.Next(3,6));
        if (rand.Next(1, 7) == 3)
        {
            StartCoroutine(FlyChicken());
            OnStop = true;

        }
        if (napravl > 0)
            napravl = -1.0F;
        else
            napravl = 1.0F;
        StartCoroutine(ChandeNapravl());
    }

    IEnumerator FlyChicken()
    {
        State = CharState.chickenFly;
        yield return new WaitForSeconds(2);
        OnStop = false;
    }
}

public enum CharState
{
    chicken1,
    chickenFly
}