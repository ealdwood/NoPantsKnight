using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool hasDiedInWater;
    public bool hasDiedOnSpikes;
    public bool hasDiedByEnemy;
    public GameObject DeathScreenUI;

    private Animator m_Anim;

    float timer = 0;
    bool timerReached = false;
    bool playedDeathSound = false;
    bool playedFailSound = false;

    bool isInCave;

    // Use this for initialization
    void Start()
    {
        hasDiedInWater = false;
        hasDiedOnSpikes = false;
        hasDiedByEnemy = false;
        isInCave = false;
        DeathScreenUI.gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForFallenPlayer();
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (hasDiedInWater ||
            hasDiedOnSpikes ||
            hasDiedByEnemy)
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!m_Anim.GetBool("isDead"))
            {
                m_Anim.SetBool("isDying", true);
            }

            if (!timerReached && timer > 0.05)
            {
                m_Anim.SetBool("isDead", true);
                m_Anim.SetBool("isDying", false);
            }

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

    private void CheckForFallenPlayer()
    {
        if (gameObject.transform.position.y < -30)
        {
            hasDiedInWater = true;
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

        if (collision.gameObject.tag == "Enemy")
        {
            hasDiedByEnemy = true;

            if (!playedDeathSound)
            {
                BroadcastMessage("PlayKilledByEnemySound");
                playedDeathSound = true;
            }
        }

        if (collision.gameObject.tag == "Cave")
        {
            if (!isInCave)
            {
                BroadcastMessage("PlayHorrorWhispersSound");
                isInCave = true;
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            if (isInCave)
            {
                BroadcastMessage("StopHorrorWhispersSound");
                isInCave = false;
            }
        }
    }

    IEnumerator Die()
    {
        m_Anim.SetBool("isDying", false);
        m_Anim.SetBool("isDead", false);

        DeathScreenUI.gameObject.SetActive(true);

        //SceneManager.LoadScene("Forest");

        yield return null;
    }
}
