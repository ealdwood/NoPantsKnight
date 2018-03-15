using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public bool hasDied;

	// Use this for initialization
	void Start () {
        hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.y < -10)
        {
            hasDied = true;
        }
		
        if (hasDied)
        {
            StartCoroutine("Die");
        }
	}

    IEnumerator Die()
    {
        SceneManager.LoadScene("Forest");
        yield return null;
    }
}
