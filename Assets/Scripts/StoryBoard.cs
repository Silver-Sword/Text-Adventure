using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StoryBoard")]
public class StoryBoard : ScriptableObject
{
    public string storyText;
    public StoryButton[] buttons;
}
