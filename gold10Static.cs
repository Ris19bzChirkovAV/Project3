using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold10Static : MonoBehaviour
{
    public GameObject gold;
    public AudioClip goldSound;
    public AudioSource audioSource;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Instantiate(gold, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            sr.color = new Vector4(0, 0, 0, 0);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(goldSound);
            Destroy(gameObject, 0.5F);
        }
    }
}
