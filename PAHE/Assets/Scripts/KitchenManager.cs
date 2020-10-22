using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Kyle Weekley
/// Manages information related to the kitchen scene
/// </summary>
public class KitchenManager : MonoBehaviour
{
    public GameObject currentSelection;
    private Image selectionIcon;

    // Start is called before the first frame update
    void Start()
    {
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Clears the currently selected object
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
