using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Trenton Plager
/// Purpose: A class to manage the data and functions that belong to a room in the pantry
/// Restrictions: None as of right now
/// </summary>
public class Room : MonoBehaviour
{
    #region Fields
    // A bool value representing whether the room is currently locked or not
    // Eventually, this would probably be set by a manager that knows if it 
    // should be locked or not depending on the state of the recipe book
    [SerializeField]
    private bool locked;                                    

    // A list of strings representing the subtypes of the room
    // This list will be used to populate the different ingredients
    // that can be taken from the room
    [SerializeField]
    private List<string> subTypes = new List<string>();
    #endregion

    #region Properties
    /// <summary>
    /// Returns whether the room is locked or not
    /// </summary>
    public bool Locked { get; set; }
    #endregion

    #region Methods
    ///Author: Trenton Plager
    /// <summary>
    /// Sets the room to be interactable and turns off the lock panel
    /// if the room is unlocked
    /// </summary>
    void Start()
    {
        if (!locked)
        {
            GetComponent<Button>().interactable = true;
            transform.Find("LockPanel").gameObject.SetActive(false);
        }
    }
    #endregion
}
