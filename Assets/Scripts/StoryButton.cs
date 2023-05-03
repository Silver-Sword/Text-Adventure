using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StoryButton")]
public class StoryButton : ScriptableObject
{
    public string buttonText;
    public ButtonBehavior behavior;
    public LockedButtonBehavior lockedBranch;
}
