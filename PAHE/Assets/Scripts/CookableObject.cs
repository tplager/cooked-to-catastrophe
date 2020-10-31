using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableObject : MonoBehaviour
{

    private bool isCooked;
    private bool isBurnt;

    // In seconds, how long till it will be done, will be counted down
    [SerializeField] private float timeToCook;
    // In seconds, how long till it will be burnt, will be counter down
    [SerializeField] private float timeToBurn;

    // How much elapsed time will count. So if 10 seconds have passed and the multiplier is 1.5, it will count as 15 seconds
    [SerializeField] private float lowHeatMultiplier;
    [SerializeField] private float mediumHeatMultiplier;
    [SerializeField] private float highHeatMultiplier;

    // How much space the object will take up in the cart
    [SerializeField] private float size;

    // Author: Nick Engell
    /// <summary>
    /// Property for how much space the object will take up in the cart
    /// </summary>
    public float Size
    {
        get { return size; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Status of whether the food is cooked or not
    /// </summary>
    public bool IsCooked
    {
        get { return isCooked; }
        set { isCooked = value; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Status of whether the food is burnt or not
    /// </summary>
    public bool IsBurnt
    {
        get { return isBurnt; }
        set { isBurnt = value; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Property for how long left till the food is cooked, and determines when the food is cooked
    /// </summary>
    public float TimeToCook
    {
        get { return timeToCook; }
        set 
        { 
            timeToCook = value; 
            if(timeToCook <= 0)
            {
                isCooked = true;
            }
        }
    }

    // Author: Nick Engell
    /// <summary>
    /// Property for how long left till the food is burnt, and determins when the food is burnt
    /// </summary>
    public float TimeToBurn
    {
        get { return timeToBurn; }
        set 
        { 
            timeToBurn = value; 
            if(timeToBurn <= 0)
            {
                isBurnt = true;
            }
        }
    }

    // Author: Nick Engell
    /// <summary>
    /// Property for how much elapsed time will count when on low heat
    /// </summary>
    public float LowHeatMultiplier
    {
        get { return lowHeatMultiplier; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Property for how much elapsed time will count when on medium heat
    /// </summary>
    public float MediumHeatMultiplier
    {
        get { return mediumHeatMultiplier; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Property for how much elapsed time will count when on high heat
    /// </summary>
    public float HighHeatMultiplier
    {
        get { return highHeatMultiplier; }
    }


}
