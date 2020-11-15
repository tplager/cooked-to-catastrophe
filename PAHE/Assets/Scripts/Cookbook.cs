using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Cookbook", menuName = "ScriptableObjects/Cookbook", order = 1)]
public class Cookbook : ScriptableObject
{
    #region Fields
    public Recipe[] recipes; 
    #endregion
}
