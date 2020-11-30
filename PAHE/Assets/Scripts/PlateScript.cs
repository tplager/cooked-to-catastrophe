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
    private Transform foodTransform;
    private GameObject foodTransferScript;
    
    /// <summary>
    /// Author: John Vance
    /// Purpose: Gets the food and sets it to a singleton that can be transfered
    /// </summary>
    public void Transfer()
    {
        
        // Gets the food on the plate
        customFood = transform.GetChild(0).gameObject;

        // Sets the food to have no parents so that a singleton can be applied to it
        foodTransform = transform.GetChild(0);
        foodTransform.SetParent(null);

        //customFood.AddComponent<FoodSingleton>();

        // Applies the singleton               
        customFood.AddComponent<FoodSingleton>();
        

    }
}
