using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip jumpSound;
    public AudioClip splashSound;
    public AudioClip spikeSplatSound;
    public AudioClip killedByEnemySound;
    public AudioClip failSound;
    public AudioClip horrorWhispersSound;
    public AudioClip killedEnemySound;

    public bool isInCave;

    private AudioSource source;
    public float volume = 1.0f;

    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isInCave = false;
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

    void PlayKilledByEnemySound()
    {
        source.PlayOneShot(killedByEnemySound, volume);
    }

    void PlayHorrorWhispersSound()
    {
        source.PlayOneShot(horrorWhispersSound, volume);
    }

    void StopHorrorWhispersSound()
    {
        source.Stop();
    }

    void PlayFailTone()
    {
        source.PlayOneShot(failSound, volume);
    }

    void PlayKilledEnemySound()
    {
        source.PlayOneShot(killedEnemySound, volume);
    }
}
