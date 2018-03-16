using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameOnSubmit : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("return"))
        {
            SceneManager.LoadScene("Forest");
        }
	}
}
