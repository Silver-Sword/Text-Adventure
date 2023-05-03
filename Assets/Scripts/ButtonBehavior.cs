using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonBehavior")]
public class ButtonBehavior : ScriptableObject
{
    public StoryButton nextScene;
    public ButtonBehavior[] buttonBehaviors;
}
