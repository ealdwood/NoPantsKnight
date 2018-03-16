using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;


public class TextBoxManager : MonoBehaviour {
    private Text dialogText;
    private Canvas canvas;
    private List<string> list;

    public void Start()
    {
        canvas = Resources.FindObjectsOfTypeAll<Canvas>().First(x => x.name == "CanvasChris");
        //Debug.Log(canvas.name);
    }
    
    private void ReadDialogTextFromFile()
    {
        list = new List<string>()
        {
            "Wow! MLC Ninja Warrior is brutal!!",
            "Damn,... wish I had of gotten the accidental death insurance when I had the chance.",
            "Do they have a cover option for this?!?",
            "I'm glad I went with MLC for Life Insurance",
            "Does MLC cover attacks from blue slime?", 
            "Underwriting didn't ask if I fight undead skeletons!",
			"I'm a celebrity, get me out of here!",
			"I'm glad I wore clean underwear today",
			"I just couldn't Hack-ett :)",
			"I guess TPD doesn't cover this?",
			"Is this excluded from my TPD cover",
			"You've won this round Terribly Angry Lizard"
        };
    }

    private void GetDialogText()
    {
        int currentLine = Random.Range(0, list.Count);

        dialogText = canvas.GetComponentInChildren<Text>();
        dialogText.text = list[currentLine];
        //Debug.Log(dialogText.text);
    }

    public void HideDeathDialog()
    {
        ToggleCanvase(false);
    }

    public void ShowDeathDialog()
    {
        //Debug.Log("Made it to show death dialog");
        ReadDialogTextFromFile();
        GetDialogText();
        ToggleCanvase(true);
    }

    private void ToggleCanvase(bool isVisible)
    {
        canvas.gameObject.SetActive(isVisible);
        //Debug.Log("Canvas toggled");
    }
}
