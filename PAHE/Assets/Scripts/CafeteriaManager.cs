using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeteriaManager : MonoBehaviour
{
    // Author: Nick Engell
    // Dictionary that holds a string for food name and a sprite for the cooked sprite of that food
    private Dictionary<string, Sprite> specials;
    // Sprite for the fried egg
    [SerializeField] private Sprite cookedEggSprite;
    // The guest info canvas panel
    [SerializeField] private GameObject guestInfo;

    // Author: Nick Engell
    /// <summary>
    /// Get property for the specials dictionary
    /// </summary>
    public Dictionary<string, Sprite> Specials
    {
        get { return specials; }
    }    

    // Author: Nick Engell
    /// <summary>
    /// Get property for the guest info canvas element
    /// </summary>
    public GameObject GuestInfo
    {
        get { return guestInfo; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupDayOneSpecials();
    }


    // Author: Nick Engell
    /// <summary>
    /// Setup the specials for day 1
    /// </summary>
    private void SetupDayOneSpecials()
    {
        // Initialize the specials dictionary
        specials = new Dictionary<string, Sprite>();
        
        // Add the specials available for day 1
        specials.Add("Fried Egg", cookedEggSprite);
    }

    // Author: Nick Engell
    /// <summary>
    /// Turns the guest info screen off
    /// </summary>
    public void CloseInfoScreen()
    {
        // Turns the guest info screen off
        guestInfo.SetActive(false);
    }
}
