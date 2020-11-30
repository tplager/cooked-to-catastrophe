using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Author: John Vance
/// Purpose: Allows for the Plate to detect if food is on it and sets it to be a singleton while on the plate
/// Restrictions: None 
/// </summary>
public class PlateScript : MonoBehaviour
{
    private GameObject customFood;

    
    public void Transfer()
    {
        customFood = transform.GetChild(0).gameObject;
        transform.GetChild(0).SetParent(null);

        customFood.AddComponent<FoodSingleton>();

    }
}
