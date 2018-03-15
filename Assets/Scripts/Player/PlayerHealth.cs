using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool hasDiedInWater;
    public bool hasDiedOnSpikes;

    float timer = 0;
    bool timerReached = false;
    bool playedDeathSound = false;
    bool playedFailSound = false;

    // Use this for initialization
    void Start()
    {
        hasDiedInWater = false;
        hasDiedOnSpikes = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (hasDiedInWater ||
            hasDiedOnSpikes)
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!timerReached && timer > 1 && !playedFailSound)
            {
                BroadcastMessage("PlayFailTone");
                playedFailSound = true;
            }

            if (!timerReached && timer > 5)
            {
                StartCoroutine("Die");

                //Set to false so that We don't run this again
                timerReached = true;
                playedDeathSound = false;
                playedFailSound = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            hasDiedInWater = true;

            if (!playedDeathSound)
            {
                BroadcastMessage("PlaySplashSound");
                playedDeathSound = true;

            }
        }

        if (collision.gameObject.tag == "Spikes")
        {
            hasDiedInWater = true;

            if (!playedDeathSound)
            {
                BroadcastMessage("PlaySpikeSplatSound");
                playedDeathSound = true;
            }
        }
    }

    IEnumerator Die()
    {
        SceneManager.LoadScene("Forest");

        yield return null;
    }
}
