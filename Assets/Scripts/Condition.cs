using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buttons/Condition")]
public class Condition : ScriptableObject
{
    // default met condition
    public virtual bool Met() { return true; }
}
