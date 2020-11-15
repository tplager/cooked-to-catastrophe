using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONRecipeReader : MonoBehaviour
{
    #region Fields
    public TextAsset jsonFile;
    public Cookbook cookbook; 
    #endregion

    // Start is called before the first frame update
    void Start()
    {        
        JsonUtility.FromJsonOverwrite(jsonFile.text, cookbook);

        foreach (Recipe recipe in cookbook.recipes)
        {
            Debug.Log($"Found Recipe: {recipe.name}");
        }
    }
}
