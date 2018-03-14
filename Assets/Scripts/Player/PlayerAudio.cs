using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioClip jumpSound;

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
}
