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
    }
}
