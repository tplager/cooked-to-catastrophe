using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Author: Kyle Weekley
/// Purpose: Allows an object to be selected and appropriately updates the current selection UI
/// Restrictions: None
/// </summary>
public class SelectableObject : MonoBehaviour, IPointerDownHandler
{
    public bool selected;
    private KitchenManager kitchenManager;
    private Image selectionIcon;


    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Sets references to objects necessary for item seleciton
    /// </summary>
    void Start()
    {
        selected = false;
        kitchenManager = GameObject.Find("Main Camera").GetComponent<KitchenManager>();
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();

    }

    void Update()
    {

    }

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Object is selected when clicked
    /// Restrictions: None
    /// </summary>
    /// <param name="eventData">Used for recognizing clicks on 2D objects</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        // Only select this object if another object is not already selected
        if (kitchenManager.currentSelection == null)
        {
            selected = true;
            kitchenManager.currentSelection = this.gameObject;

            //Set current selection sprite in UI to this object's sprite
            //selectionIcon.sprite = this.GetComponent<Image>().sprite;

            //Currently using sprite color for testing
            selectionIcon.color = this.GetComponent<Image>().color;
        }
    }

    
}
