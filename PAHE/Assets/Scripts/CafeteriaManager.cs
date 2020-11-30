using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CafeteriaManager : MonoBehaviour
{
    // Author: Nick Engell, Kyle Weekley
    // Dictionary that holds a string for food name and a sprite for the cooked sprite of that food
    private Dictionary<string, Sprite> specials;
    // List that holds guest gameObjects
    private List<GameObject> guests;
    // Dictionary of accepted guest orders and quantities
    private Dictionary<string, int> orders;
    // Guest prefab
    [SerializeField] private GameObject guest;
    //Canvas reference for guest instantiation
    [SerializeField] private Canvas guestCanvas;
    //Locations to spawn guests
    [SerializeField] private Vector3 guestPositionLeft;
    [SerializeField] private Vector3 guestPositionCenter;
    [SerializeField] private Vector3 guestPositionRight;
    // Sprite for the fried egg
    [SerializeField] private Sprite cookedEggSprite;
    // Sprite for rice
    [SerializeField] private Sprite cookedRiceSprite;
    // Sprite for spaghetti & meatballs
    [SerializeField] private Sprite cookedSpaghettiMeatballSprite;
    // The guest info canvas panel
    [SerializeField] private GameObject guestInfo;
    // The button to close the guest info canvas panel
    [SerializeField] private Button guestInfoCloseButton;
    // Specials list UI object
    [SerializeField] private GameObject specialsUIItemText;

    // Author: Kyle Weekley, Ben Stern
    /// <summary>
	/// the singleton instance
	/// </summary>
	private static CafeteriaManager _instance;

    // Author: Kyle Weekley, Ben Stern
    /// <summary>
    /// the instance of the cart manager
    /// </summary>
    public static CafeteriaManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CafeteriaManager");
                _instance = obj.AddComponent<CafeteriaManager>();
            }
            return _instance;
        }
    }

    // Author: Nick Engell
    /// <summary>
    /// Get property for the specials dictionary
    /// </summary>
    public Dictionary<string, Sprite> Specials
    {
        get { return specials; }
    }

    // Author: Kyle Weekley
    /// <summary>
    /// Get property for the orders dictionary
    /// </summary>
    public Dictionary<string, int> Orders
    {
        get { return orders; }
    }

    // Author: Nick Engell
    /// <summary>
    /// Get property for the guest info canvas element
    /// </summary>
    public GameObject GuestInfo
    {
        get { return guestInfo; }
    }

    // Author: Kyle Weekley, Ben Stern
    /// <summary>
    /// Called before Start to handle singleton setup
    /// </summary>
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        //because cafeteria manager is not destroyed when new scenes are loaded we need to reget certain elements when entering a new scene
        SceneManager.sceneLoaded += OnSceneLoaded;

        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    // Set up everything needed for Day 1
    void Start()
    {
        SetupDayOneSpecials();
        SetupDayOneGuests();
        orders = new Dictionary<string, int>();
    }


    // Author: Nick Engell, Kyle Weekley
    /// <summary>
    /// Setup the specials for day 1
    /// </summary>
    private void SetupDayOneSpecials()
    {
        // Initialize the specials dictionary
        specials = new Dictionary<string, Sprite>();
        
        // Add the specials available for day 1
        // These names should definitely be grabbed from the cookbook json file but I don't feel like changing it right now sorry
        specials.Add("Over-Medium Fried Egg", cookedEggSprite);
        specials.Add("Long Grain White Rice", cookedRiceSprite);
        specials.Add("Spaghetti & Meatballs", cookedSpaghettiMeatballSprite);

        //Populate specials UI
        SetupSpecialsUI(specials);
    }

    // Author: Kyle Weekley
    /// <summary>
    /// Create guests for day 1
    /// </summary>
    private void SetupDayOneGuests()
    {
        //Initialize guest list
        guests = new List<GameObject>();

        //Create three guests, each ordering one of our MVP specials
        SetupGuest(guestPositionLeft, specials.Keys.ToArray()[0]);
        SetupGuest(guestPositionCenter, specials.Keys.ToArray()[1]);
        SetupGuest(guestPositionRight, specials.Keys.ToArray()[2]);
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

    // Author: Kyle Weekley
    /// <summary>
    /// Populates specials UI element with the current specials
    /// </summary>
    /// <param name="currentSpecials">Dictionary of the day's specials</param>
    public void SetupSpecialsUI(Dictionary<string, Sprite> currentSpecials)
    {
        //Clear specials UI text
        specialsUIItemText.GetComponent<Text>().text = "";

        //Set Specials UI text to match available specials
        foreach (KeyValuePair<string, UnityEngine.Sprite> special in specials)
        {
            //Add special name to specials UI text followed by two line breaks
            specialsUIItemText.GetComponent<Text>().text += "- " + special.Key + "\r\n\r\n";
        }
    }

    // Author: Kyle Weekley
    /// <summary>
    /// Creates a guest with or without specified order
    /// </summary>
    /// <param name="order">Optionally specified order the guest will ask for</param>
    public void SetupGuest(Vector3 position, string order = null)
    {
        //Instantiate guest at the proper position
        GameObject newGuest = Instantiate(guest, position, Quaternion.identity);

        //Set guest as a child of canvas
        newGuest.transform.SetParent(guestCanvas.transform, false);

        //Set guest's order if specified
        //Otherwise guest will make a random order on its own
        if (order != null)
        {
            newGuest.GetComponent<Guest>().orderKeyRequested = order;
        }

        //Add guest to guest list
        guests.Add(newGuest);
    }

    // Author: Kyle Weekley
    /// <summary>
    /// Removes a guest from the guest list
    /// To be called when a guest has received their order and leaves the restaurant
    /// </summary>
    /// <param name="removedGuest">Guest object to be removed from list</param>
    public void RemoveGuestFromList(GameObject removedGuest)
    {
        guests.Remove(removedGuest);
    }

    // Author: Kyle Weekley, Ben Stern
    /// <summary>
    /// Is  called when a new scene is loaded
    /// </summary>
    /// <param name="scene">the scene being loaded</param>
    /// <param name="mode">the way the scene is being loaded</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Pantry" || scene.name == "133-Pantry")
        {
            guestCanvas.enabled = false;
        }
        else if (scene.name == "Kitchen" || scene.name == "129 Kitchen")
        {
            guestCanvas.enabled = false;
        }
        else if (scene.name == "Cafeteria" || scene.name == "129 Cafeteria")
        {
            guestCanvas.enabled = true;
            // You can't find an inactive gameObject, so this needs some extra steps
            guestInfo = GameObject.Find("UICanvas");
            guestInfo = guestInfo.transform.Find("Guest Info").gameObject;
            specialsUIItemText = GameObject.Find("/Canvas/SpecialsUI/ItemText");
            guestInfoCloseButton = guestInfo.GetComponentInChildren<Button>();
            // Set the close button's onClick behavior to close the menu
            // This is done here as well as in-editor because the button will lose its reference to the CafeteriaManager singleton after scene switches
            guestInfoCloseButton.onClick.AddListener(CloseInfoScreen);
        }
    }

    // Author: Kyle Weekley, Ben Stern
    /// <summary>
    /// Remove from scene manager when the program is closed
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
