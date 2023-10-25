using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buttons/StoryBoard")]
[System.Serializable]
public class StoryBoard : ScriptableObject
{
    [TextArea(5, 15)] public string storyText;
    public StoryButton[] buttons;
}
