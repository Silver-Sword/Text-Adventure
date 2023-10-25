using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button texts
[System.Serializable]
public class StoryButton
{
    [TextArea(5, 15)] public string buttonText;
    public Condition[] visibilityCondition;
    public ButtonBehavior behavior;

    public bool Visible()
    {
        if(visibilityCondition == null) return true;

        foreach(Condition condition in visibilityCondition)
            if(!condition.Met())
                return false;
        return true;
    }

    // return the current text of the button
    public string GetText()
    {
        return buttonText;
    }

    public StoryBoard TriggerButton()
    {
        return behavior.Execute();
    }
}
