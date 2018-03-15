using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenPlayerClose : MonoBehaviour {

    private float distanceToPlayer;
    private bool hasApproached;
    public AudioClip sound;
    public float distanceIsClose;

    private AudioSource source;
    
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        hasApproached = false;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindWithTag("Player");

        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distanceToPlayer < distanceIsClose)
        {
            if (!hasApproached)
            {
                PlayEnemySound();
            }
            hasApproached = true;
        }
        else
        {
            hasApproached = false;
        }

    }

    void PlayEnemySound()
    {
        source.PlayOneShot(sound, 1F);
    }
}
