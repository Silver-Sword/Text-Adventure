using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buttons/StoryBoard")]
public class StoryBoard : ScriptableObject
{
    [TextArea(5, 15)] public string storyText;
    public StoryButton[] buttons;
}
