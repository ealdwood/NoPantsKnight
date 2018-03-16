using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft = 120f;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject scoreUI;
    public GameObject deathScoreUI;
    public GameObject endScreenUI;
    public GameObject endScoreUI;

    void Start()
    {
        endScreenUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log("Time Left" + timeLeft);
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        deathScoreUI.gameObject.GetComponent<Text>().text = ("Your score was: " + playerScore);
        endScoreUI.gameObject.GetComponent<Text>().text = ("Your score was: " + playerScore);
        

        //Debug.Log(timeLeft);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Forest");
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "End")
        {
            CountScore();
            endScoreUI.gameObject.GetComponent<Text>().text = ("Your score was: " + playerScore);
            endScreenUI.gameObject.SetActive(true);
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "Egg")
        {
            playerScore += 100;
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "Pants")
        {
            playerScore += 500;
            Destroy(collider.gameObject);
        }
    }

    void CountScore()
    {
        playerScore += (int)(timeLeft * 10);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }
}