using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip cosmic;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(cosmic);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartCoroutine(StopPlay());
    }

    IEnumerator StopPlay()
    {
        yield return new WaitForSeconds(0.1F);
        if (audioSource.volume > 0.2F)
        {
            audioSource.volume -= 0.05F;
            StartCoroutine(StopPlay());
        }
        else
        {
            audioSource.Stop();
            audioSource.volume = 1.0F;
        }
    }
}