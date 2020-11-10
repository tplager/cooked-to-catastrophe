﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: John Vance
/// Purpose: Allows for the Spatula to be used
/// Restrictions: Only able to be used on the Egg currently
/// </summary>
public class SpatulaScript : MonoBehaviour
{
    private InteractableBase interactableBase;  // The assest's InteractableBase script

    void Start()
    {
        // Gets the InteractableBase script on the object
        interactableBase = GetComponent<InteractableBase>();
        // Adds the interaction
        interactableBase.AddInteractionToList("Put Back Spatula", SpatulaToCup);
        interactableBase.AddInteractionToList("Take Egg", SpatulaGrab);

    }


    /// <summary>
    /// Author: John Vance
    /// Purpose: Allows for the Spatula to be moved to the Utensil Cup
    /// </summary>
    /// <param name="utensilCup">The utensil Cup</param>
    public void SpatulaToCup(InteractableBase utensilCup)
    {
        if (transform.childCount <= 0)
        {
            transform.position = utensilCup.transform.position + new Vector3(0.0f, 70.0f, 0.0f);

        }

    }


    /// <summary>
    /// Author: John Vance
    /// Purpose: Allows for the Spatula to pick up the egg and move it to the plate
    /// Restrictions: None
    /// </summary>
    /// <param name="container">The container that the Spatula is acting on</param>
    public void SpatulaGrab(InteractableBase container)
    {
        transform.position = container.transform.position - new Vector3(0.0f, 20.0f, 0.0f);// + PlacePositionRelative;

    }

}
