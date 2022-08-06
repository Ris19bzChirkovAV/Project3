using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip poof;
    SpriteRenderer sr;
    [SerializeField] float time;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(poof);
        StartCoroutine(time1());
    }

    void Update()
    {
        if (!audioSource.isPlaying)
            Destroy(gameObject);
    }

    IEnumerator time1()
    {
        yield return new WaitForSeconds(time);
        sr.color = new Vector4(0, 0, 0, 0);
    }
}
