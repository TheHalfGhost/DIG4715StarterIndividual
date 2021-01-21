using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starttext : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip Startnoise;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Startnoise);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
