using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class StoryController : MonoBehaviour
{
    // public objects to set
    public StoryBoard start;
    public GameObject storyTextObject;

    // constants
    public const int MAX_BUTTONS = 10;

    // optionLayouts holds the scripts for all the different button quantities layouts
    private StoryOptions[] optionLayouts = new StoryOptions[MAX_BUTTONS + 1];

    // constants that are generated from gameobjects
    private TextMeshPro storyText;

    // trackers
    private StoryBoard currentStory;
    private StoryOptions currentOptions;
    private StoryButton[] currentButtons;

    void Awake()
    {
        // grab the story text
        storyText = storyTextObject.GetComponent<TextMeshPro>();

        // automatically put the option layouts that exist in the layouts array
        StoryOptions[] optionsInScene = GameObject.FindObjectsOfType<StoryOptions>(true);
        foreach(StoryOptions so in optionsInScene)
        {
            if(so.CountButtons() > MAX_BUTTONS)
            {
                Debug.LogError("Number of Options in the layout exceeded " + MAX_BUTTONS);
                continue;
            }

            optionLayouts[so.CountButtons()] = so;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStory = start;
        SetupPage(start);
    }

    void SetupPage(StoryBoard board)
    {
        // set story text
        SetStoryText(board.storyText);

        // set options
        SetButtons(board.buttons);
    }

    void SetStoryText(string story)
    {
        if(storyText == null)
        {
            Debug.LogError("story text not set in StoryController object");
            return;
        }

        storyText.text = story;
    }

    void SetButtons(StoryButton[] allButtons)
    {
        // reduce the buttons to only the visible ones
        List<StoryButton> full = new List<StoryButton>(allButtons);

        for(int i = full.Count - 1; i >= 0; i--)
        {
            if(!full[i].Visible())
                full.RemoveAt(i);
        }

        int numButtons = full.Count;

        if(optionLayouts[numButtons] == null)
        {
            Debug.LogError("tried to switch to a page with an invalid number of buttons (" + numButtons + ")");
            return;
        }
        
        // set current trackers
        currentButtons = new StoryButton[numButtons];
        for(int i = 0; i < numButtons; i++)
            currentButtons[i] = full[i];

        optionLayouts[numButtons].SetButtonText(currentButtons);

        currentOptions = optionLayouts[numButtons];
    }

    void ChooseButton(int buttonIndex)
    {
        if(buttonIndex >= currentButtons.Length)
        {
            Debug.LogError("Button Choice index out of range (index=" + buttonIndex + ")");
            return;
        }

        // remove old page and set new page
        currentOptions.SetButtons(false);
        
        currentStory = currentButtons[buttonIndex].TriggerButton();
        SetupPage(currentStory);
    }
}
