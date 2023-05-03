using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedButtonBehavior : ScriptableObject
{
    public bool isLocked;
    public ButtonBehavior lockedBehavior;
    // what is it locked behind?
}
