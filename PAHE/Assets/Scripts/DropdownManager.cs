using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: John Vance
/// Purpse: Manage the dropdown system for objects
/// Restrictions: None currently
/// </summary>
public class DropdownManager : MonoBehaviour
{
    // The number of the selected dropdown
    [SerializeField]
    private int val;


    // Properties
    public int Val
    {
        get { return val; }
        set { val = value; }

    }

   
   
    
}
