using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioClip jumpSound;
    public AudioClip splashSound;
    public AudioClip spikeSplatSound;
    public AudioClip failSound;

    private AudioSource source;
    public float volume = 1.0f;

    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound, volume);
    }

    void PlaySplashSound()
    {
        source.PlayOneShot(splashSound, volume);
    }

    void PlaySpikeSplatSound()
    {
        source.PlayOneShot(spikeSplatSound, volume);
    }

    void PlayFailTone()
    {
        source.PlayOneShot(failSound, volume);
    }
}
