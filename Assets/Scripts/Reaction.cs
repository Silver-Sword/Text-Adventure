using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buttons/Reaction")]
public class Reaction : ScriptableObject
{
    public virtual void Execute() {}
}
