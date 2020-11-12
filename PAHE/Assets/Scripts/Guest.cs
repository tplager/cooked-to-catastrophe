using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{

    private bool hasKey;

    // Variable that holds the order the customer wants
    // Fill in later when the cafeteria manager has an enum for it
    // private BLANK foodOrder

    private List<string> dialogueLines;

    [SerializeField] private Sprite neturalFace;
    [SerializeField] private Sprite happyFace;
    [SerializeField] private Sprite sadFace;

    // Start is called before the first frame update
    void Start()
    {
        // Initialized the dialogueLines list
        dialogueLines = new List<string>();
        // Populated the list with some possible lines
        dialogueLines.Add("Man, it smells so good in here compared to outside.");
        dialogueLines.Add("Oooo, this is gonna be good!");
        dialogueLines.Add("Can't really find much good food out there.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Author: Nick Engell
    /// <summary>
    /// Returns a random dialogue line from the list of possible dialogue lines
    /// </summary>
    /// <returns>A random string from the list of dialogue lines</returns>
    public string GetRandomDialogueLine()
    {
        return dialogueLines[Random.Range(0, dialogueLines.Count)];
    }

    public void PickOrder()
    {
        // Get a random? order from the cafeteria manager and set the foodOrder to it
    }

    public void CompareDishAndOrder()// Insert order enum here
    {
        // Check to see if the recieved dish is the same as the foodOrder, if so display happy, else sad

        // Change the guest info headshot to happy or sad
    }

    // Called when the guest is clicked on
    public void UpdateGuestInfo()
    {
        // Get the text fields in the info panel
        // Update the greeting text with a random dialogue line with a "- " at the beginning
        // Update the meal text with the dish name
        // Update the dish icon with the correct dish

        // The dishes in the cafeteria manager might be a dictionary / list of vectors. Something that can hold the dish name and the dish icon.

        // Update the guest photo to be the happy face for 1 second then go to neutral
    }
}
