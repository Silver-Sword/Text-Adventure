using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the GameManager handles the static variables that exist across plays
public class GameManager : MonoBehaviour
{
    // states is the collection of static variables within the game itself
    Dictionary<string, int> states;
    private static GameManager Instance;
    
    // initializes Singleton or destroys this script if it already exists
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            states = new Dictionary<string, int>();
        }
        else
        {
            Destroy(this);
        }
    }
    // returns the singleton
    public static GameManager GetInstance()
    {
        if(Instance == null)
        {
            Debug.LogError("GameManager is being accessed, but its Instance is null");
        }
        return Instance;
    }

    /**
        Methods for the states dictionary
    **/
    // returns if the flag has already been added to states
    public bool StateExists(string flag)
    {
        return states.ContainsKey(flag);
    }
    // return the boolean state of flag (0 or absent is false, anything else is true)
    public bool GetFlag(string flag)
    {
        if(!StateExists(flag)) return false;
        return states[flag] != 0;
    }

    // returns the integer associated with flag, where 0 is the default value
    public int GetState(string flag)
    {
        if(!StateExists(flag)) return 0;
        return states[flag];
    }

    // sets the flag state to value
    public void SetState(string flag, int value)
    {
        if(StateExists(flag)) states[flag] = value;
        else states.Add(flag, value);
    }

    // subtracts one from the state
    public void DecrementState(string flag)
    {
        SetState(flag, GetState(flag) - 1);
    }

    // adds one to the state
    public void IncrementState(string flag)
    {
        SetState(flag, GetState(flag) + 1);
    }

}
