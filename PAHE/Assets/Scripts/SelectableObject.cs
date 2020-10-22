using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Author: Kyle Weekley
/// Allows an object to be selected and appropriately updates the current selection UI
/// </summary>
public class SelectableObject : MonoBehaviour, IPointerDownHandler
{
    public bool selected;
    private KitchenManager kitchenManager;
    private Image selectionIcon;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        kitchenManager = GameObject.Find("Main Camera").GetComponent<KitchenManager>();
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        // Highlight object if selected
        if (selected == true)
        {
            //TODO: Highlight object edges
        }
    }

    /// <summary>
    /// Object is selected when clicked
    /// </summary>
    /// <param name="eventData"></param>
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
