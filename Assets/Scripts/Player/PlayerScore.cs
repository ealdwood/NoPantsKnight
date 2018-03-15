using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
    public float timeLeft = 120f;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playScoreUI;
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Time Left" + timeLeft);
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        timeLeft -= Time.deltaTime;
        Debug.Log(timeLeft);
		if(timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Desert");
        }

	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        CountScore();
    }

    void CountScore()
    {
        playerScore += (int)(timeLeft * 10);
        Debug.Log("Player Score" + playerScore);
    }
}
