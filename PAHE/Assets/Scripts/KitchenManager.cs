using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Kyle Weekley
/// Purpose: Manages information related to the kitchen scene
/// Restrictions: None
/// </summary>
public class KitchenManager : MonoBehaviour
{
    public GameObject currentSelection;
    private Image selectionIcon;

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Set references to necessary objects
    /// </summary>
    void Start()
    {
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();
    }

    void Update()
    {
        
    }

	/// Author: Ben Stern
	/// <summary>
	/// Attempt to select an object or interact with it in some way
	/// </summary>
	/// <param name="selectedObject">The is attempting to be selected</param>
	public void ObjectSelected(SelectableObject selectedObject)
	{
		if(currentSelection == null)
		{
			selectedObject.selected = true;
			currentSelection = selectedObject.gameObject;
			selectionIcon.color = selectedObject.GetComponent<Image>().color;
		}
		else
		{
			//TODO: call interactable object methods
		}
	}

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Clears the currently selected object
    /// Restrictions: None
    /// </summary>
    public void ClearSelection()
    {
        currentSelection = null;

        //Reset selection sprite
        //selectionIcon.sprite = null;

        //Currently using sprite color for testing
        selectionIcon.color = Color.white;
    }
}
