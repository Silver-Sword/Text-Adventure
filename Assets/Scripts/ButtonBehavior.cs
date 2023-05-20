using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonBehavior
{
    public StoryBoard nextScene;
    public Reaction[] buttonBehaviors;

    public StoryBoard Execute()
    {
        foreach(Reaction action in buttonBehaviors)
            action.Execute();
        
        return nextScene;
    }
}
