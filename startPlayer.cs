using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip blair1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(go());
        audioSource = GetComponent<AudioSource>();
        
    }

    IEnumerator go()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(blair1);
        rb.AddForce(new Vector3(0, 0.001F, 0), ForceMode2D.Impulse);
        StartCoroutine(stop());
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<PlayerCtrl>().enabled = true;
        this.enabled = false;
    }
}
