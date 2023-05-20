using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Holds the buttons for a story board collection
// I.e. holds and controls the buttons for a particular story page
public class StoryOptions : MonoBehaviour
{
    public GameObject[] buttons;
    private TextMeshPro[] buttonText;

    void Awake()
    {
        if(buttons == null)
        {
            Debug.LogWarning("No buttons set in a StoryOptions script");
            return;
        }

        buttonText = new TextMeshPro[buttons.Length];
        for(int i = 0; i < buttons.Length; i++)
            buttonText[i] = buttons[i].GetComponentInChildren<TextMeshPro>();

        // set off by default
        SetButtons(false);
    }   

    // set the button states
    public void SetButtons(bool active)
    {
        foreach(GameObject obj in buttons)
            if(obj != null)
                obj.SetActive(active);
    }

    public void SetButtonText(StoryButton[] buttons)
    {
        SetButtons(true);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttonText[i].text = buttons[i].GetText();
        }
    }

    // returns the number of buttons for this page
    public int CountButtons()
    {
        return buttons.Length;
    }
}
