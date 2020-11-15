using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    #region Fields
    public string name;
    public string[] ingredients;
    public string[] instructions;
    public string[] sources;
    public bool unlocked; 
    #endregion
}
