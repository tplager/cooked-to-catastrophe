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
    public SelectableObject currentSelection;
    private Image selectionIcon;

    [SerializeField]
    private GameObject stoveTopRightUI;
    [SerializeField]
    private GameObject stoveTopLeftUI;
    [SerializeField]
    private GameObject stoveBottomRightUI;
    [SerializeField]
    private GameObject stoveBottomLeftUI;

    private GameObject[] stoveDialArray;

    private GameObject stove;

    // Author: Nick Engell
    /// <summary>
    /// Get access to the stove
    /// </summary>
    public GameObject Stove
    {
        get { return stove; }
    }

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Set references to necessary objects
    /// </summary>
    void Start()
    {
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();

        //stoveTopRightUI = GameObject.Find("TopRightBurnerUI").gameObject;           // Gets the reference to the Top Right Burner
        //stoveTopLeftUI = GameObject.Find("TopLeftBurnerUI").gameObject;             // Gets the reference to the Top Left Burner
        //stoveBottomRightUI = GameObject.Find("BottomRightBurnerUI").gameObject;     // Gets the reference to the Bottom Right Burner
        //stoveBottomLeftUI = GameObject.Find("BottomLeftBurnerUI").gameObject;       // Gets the reference to the Bottom Left Burner

        // Find and store a reference to the stove object
        stove = GameObject.Find("Stove");

        // Puts the UI elements into the array
        stoveDialArray = new GameObject[] { stoveTopRightUI, stoveTopLeftUI, stoveBottomRightUI, stoveBottomLeftUI };

        // Turns off each burner till it needs to be used
        foreach(GameObject element in stoveDialArray)
        {
            element.SetActive(false);
        }
        

    }


    void Update()
    {
        if (currentSelection != null)
        {
            CheckStove();

        }


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
			currentSelection = selectedObject;
			selectionIcon.color = selectedObject.GetComponent<Image>().color;
			selectionIcon.sprite = selectedObject.GetComponent<Image>().sprite;
		}
		else
		{
			//TODO: call interactable object methods
			InteractableBase currentInteractable = currentSelection.GetComponent<InteractableBase>();
			InteractableBase selectedInteractable = selectedObject.GetComponent<InteractableBase>();
			if(currentInteractable != null && selectedInteractable != null)
			{
				if (selectedInteractable.AttemptInteraction(currentInteractable))
				{
					ClearSelection();
				}
			}
		}
	}

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Clears the currently selected object
    /// Restrictions: None
    /// </summary>
    public void ClearSelection()
    {

		if (currentSelection != null)
		{
			currentSelection.selected = false;
		}
		currentSelection = null;
        
        // Clears the Stove UI when the Clear Selection button is pressed
        foreach (GameObject element in stoveDialArray)
        {
            element.SetActive(false);

        }

        //Reset selection sprite
        selectionIcon.sprite = null;
		selectionIcon.color = Color.white;

        //Currently using sprite color for testing
        //selectionIcon.color = Color.white;
    }

    /// <summary>
    /// Author: John Vance
    /// Purpose: Allows for the Stove UI to open.
    /// Restrictions: None.
    /// </summary>
    public void CheckStove()
    {
        foreach(GameObject element in stoveDialArray)
        {
            if (currentSelection.tag == element.tag)
            {
                element.SetActive(true);

            }

            else
            {
                element.SetActive(false);


            }
        }
        

    }

    /// <summary>
    /// Author: John Vance
    /// Purpose: Allows for the player to leave a Burner Menu
    /// </summary>
    /// <param name="burner">The Burner the player is affecting</param>
    public void Leave(GameObject burner)
    {
        burner.SetActive(false);
        ClearSelection();

    }
}
