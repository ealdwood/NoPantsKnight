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
        canvas = Resources.FindObjectsOfTypeAll<Canvas>().First();
    }
    
    private void ReadDialogTextFromFile()
    {
        list = new List<string>()
        {
            "Wow! MLC Ninja Warrior is brutal!!",
            "Damn,... wish I had of gotten the accidental death insurance when I had the chance.",
            "Do they have a cover option for this?!?",
            "Nav wears womens underwear!!!!"
        };
    }

    private void GetDialogText()
    {
        int currentLine = Random.Range(0, list.Count);

        dialogText = canvas.GetComponentInChildren<Text>();
        dialogText.text = list[currentLine];
    }

    public void HideDeathDialog()
    {
        ToggleCanvase(false);
    }

    public void ShowDeathDialog()
    {
        ReadDialogTextFromFile();
        GetDialogText();
        ToggleCanvase(true);
    }

    private void ToggleCanvase(bool isVisible)
    {
        canvas.gameObject.SetActive(isVisible);
    }
}
