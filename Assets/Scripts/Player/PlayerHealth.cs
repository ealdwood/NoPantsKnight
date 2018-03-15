using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public bool hasDiedInWater;
    public bool hasDiedOnSpikes;

    float timer = 0;
    bool timerReached = false;
    bool playedDeathSound = false;
    bool playedFailSound = false;

    // Use this for initialization
    void Start () {
        hasDiedInWater = false;
        hasDiedOnSpikes = false;

    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.y < -10)
        {
            hasDiedInWater = true;

            if (!playedDeathSound)
            {
                BroadcastMessage("PlaySplashSound");
                playedDeathSound = true;
            }
                      
        }

        else if (gameObject.transform.position.y < -10)
        {
            hasDiedOnSpikes = true;

            if (!playedDeathSound)
            {
                BroadcastMessage("PlaySpikesSplatSound");
                playedDeathSound = true;
            }
        }

        if (hasDiedInWater || hasDiedOnSpikes)
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

    IEnumerator Die()
    {
        SceneManager.LoadScene("Forest");

        yield return null;
    }
}
