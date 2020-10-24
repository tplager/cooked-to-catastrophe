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
    private GameObject stoveTopRightUI;
    private GameObject stoveTopLeftUI;
    private GameObject stoveBottomRightUI;
    private GameObject stoveBottomLeftUI;

    private GameObject[] stoveDialArray;

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Set references to necessary objects
    /// </summary>
    void Start()
    {
        selectionIcon = GameObject.Find("Selection Sprite").GetComponent<Image>();

        stoveTopRightUI = GameObject.Find("TopRightBurnerUI").gameObject;           // Gets the reference to the Top Right Burner
        stoveTopLeftUI = GameObject.Find("TopLeftBurnerUI").gameObject;             // Gets the reference to the Top Left Burner
        stoveBottomRightUI = GameObject.Find("BottomRightBurnerUI").gameObject;     // Gets the reference to the Bottom Right Burner
        stoveBottomLeftUI = GameObject.Find("BottomLeftBurnerUI").gameObject;       // Gets the reference to the Bottom Left Burner

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

    /// <summary>
    /// Author: Kyle Weekley
    /// Purpose: Clears the currently selected object
    /// Restrictions: None
    /// </summary>
    public void ClearSelection()
    {
        currentSelection = null;
        
        // Clears the Stove UI when the Clear Selection button is pressed
        foreach (GameObject element in stoveDialArray)
        {
            element.SetActive(false);

        }

        //Reset selection sprite
        selectionIcon.sprite = null;

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
}
