using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Author: John Vance
/// Purpose: Allows for the Plate to detect if food is on it and sets it to be a singleton while on the plate
/// Restrictions: None 
/// </summary>
public class PlateScript : MonoBehaviour
{
    private GameObject customFood;
    private Transform foodTransform;
    private GameObject newFood;

    private List<string> names;
    private List<GameObject> objects;

    [SerializeField]
    private Sprite USPFM;    // Uncooked Spaghetti and Frozen Meatballs
    [SerializeField]
    private Sprite USPCM;    // Uncooked Spaghetti and Cooked Meatballs
    [SerializeField]
    private Sprite USPBM;    // Uncooked Spaghetti and Burned Meatballs
    [SerializeField]
    private Sprite BSPFM;    // Burned Spaghetti and Frozen Meatballs
    [SerializeField]
    private Sprite BSPCM;    // Burned Spaghetti and Cooked Meatballs
    [SerializeField]
    private Sprite BSPBM;    // Burned Spaghetti and Burned Meatballs
    [SerializeField]
    private Sprite CSPFM;    // Cooked Spaghetti and Frozen Meatballs
    [SerializeField]
    private Sprite CSPCM;    // Cooked Spaghetti and Cooked Meatballs
    [SerializeField]
    private Sprite CSPBM;    // Cooked Spaghetti and Burned Meatballs

    private bool cooked;

    void Start()
    {
        names = new List<string>();
        objects = new List<GameObject>();
    }

    void Update()
    {
        if(this.gameObject.transform.childCount > 2)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                names.Add(transform.GetChild(i).GetComponent<Image>().sprite.name);
                objects.Add(transform.GetChild(i).gameObject);
                if (transform.GetChild(i).name == "Spaghetti")
                {
                    newFood = transform.GetChild(i).gameObject;
                }
            }

            for (int i = 0; i < objects.Count; i++)
            {
                if(objects[i].GetComponent<CookableObject>() != null)
                {
                    cooked = objects[i].GetComponent<CookableObject>().IsCooked;
                    if(cooked == false)
                    {
                        i = objects.Count;
                    }

                }

            }

            if (names.Contains("SpaghettiUncooked") && names.Contains("MeatballsFrozen"))
            {
                SetImgDelete(USPFM, objects, newFood);
                
            }

            else if (names.Contains("SpaghettiUncooked") && names.Contains("MeatballsBurned"))
            {
                SetImgDelete(USPBM, objects, newFood);

            }

            else if (names.Contains("SpaghettiUncooked") && names.Contains("Meatballs"))
            {
                SetImgDelete(USPCM, objects, newFood);

            }

            else if (names.Contains("SpaghettiPrepped") && names.Contains("MeatballsFrozen"))
            {
                SetImgDelete(CSPFM, objects, newFood);

            }

            else if (names.Contains("SpaghettiPrepped") && names.Contains("MeatballsBurned"))
            {
                SetImgDelete(CSPBM, objects, newFood);

            }

            else if (names.Contains("SpaghettiPrepped") && names.Contains("Meatballs"))
            {
                SetImgDelete(CSPCM, objects, newFood);

            }

            else if (names.Contains("SpaghettiBurned") && names.Contains("MeatballsFrozen"))
            {
                SetImgDelete(BSPFM, objects, newFood);

            }

            else if (names.Contains("SpaghettiBurned") && names.Contains("MeatballsBurned"))
            {
                SetImgDelete(BSPBM, objects, newFood);

            }

            else if (names.Contains("SpaghettiBurned") && names.Contains("Meatballs"))
            {
                SetImgDelete(BSPCM, objects, newFood);

            }


        }


    }


    public void SetImgDelete(Sprite img, List<GameObject> list, GameObject food)
    {
        food.GetComponent<Image>().sprite = img;
        food.GetComponent<CookableObject>().IsCooked = cooked;
        int x = list.Count - 1;
        while(x != 0)
        {
            if(list[x].name != "Spaghetti")
            {
                GameObject tempObj = list[x];
                list.RemoveAt(x);
                Destroy(tempObj);
                x--;
            }

            if(!list.Contains(food))
            {
                x = 0;
            }

        }


    }


    /// <summary>
    /// Author: John Vance
    /// Purpose: Gets the food and sets it to a singleton that can be transfered
    /// </summary>
    public void Transfer()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            customFood = null;
            foodTransform = null;

            // Gets the food on the plate
            customFood = transform.GetChild(i).gameObject;

            // Sets the food to have no parents so that a singleton can be applied to it
            foodTransform = transform.GetChild(i);
            foodTransform.SetParent(null);

            // Applies the singleton               
            customFood.AddComponent<FoodSingleton>();

        }

    }
}
