using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SauceStates
{
    Jar, 
    Loose, 
    Scorched, 
    Plated
}

[RequireComponent(typeof(InteractableBase))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CookableObject))]
public class SauceScript : MonoBehaviour
{
    //various components of that the script keeps track of
    private InteractableBase interactableComponent;
    private Image imageComponent;

    /// <summary>
    /// The current state of the sauce
    /// </summary>
    private SauceStates sauceState;

    /// <summary>
    /// The image representing the sauce when it is still in the jar
    /// </summary>
    [SerializeField]
    private Sprite jarImage;

    /// <summary>
    /// the image repsenting the sauce when it is out of the jar
    /// </summary>
    [SerializeField]
    private Sprite looseImage;

    /// <summary>
    /// the image representing the the sauce when it is scorched
    /// </summary>
    [SerializeField]
    private Sprite scorchedImage;

        /// <summary>
    /// the image representing the the sauce when it is on the plate
    /// </summary>
    [SerializeField]
    private Sprite platedImage;

    void Start()
    {
        //get the interactable component and add interactions to it
        interactableComponent = GetComponent<InteractableBase>();
        interactableComponent.AddInteractionToList("On Place In Container", OnPlaceInContainer);
        interactableComponent.AddInteractionToList("Place On Plate", OnPlaceOnPlate);

        //get the image component and set the sprite
        imageComponent = GetComponent<Image>();

        ChangeSauceState(SauceStates.Jar);
    }

    // Author: Nick Engell
    /// <summary>
    /// Updates the egg state and image based on the food cook state
    /// </summary>
    private void Update()
    {
        // If the sauce is scorched
        if (GetComponent<CookableObject>().IsBurnt)
        {
            ChangeSauceState(SauceStates.Scorched);
        }
    }

    //takes an interactable base so it can be a delegate
    /// <summary>
    /// A function to call when the egg is placed in to a container
    /// </summary>
    /// <param name="container">the container the egg is being placed in</param>
    public void OnPlaceInContainer(InteractableBase container)
    {
        //if the egg is currently shelled, unshell it
        if (sauceState == SauceStates.Jar)
        {
            ChangeSauceState(SauceStates.Loose);
        }
    }

    //takes an interactable base so it can be a delegate
    /// <summary>
    /// A function to call when the egg is placed in to a container
    /// </summary>
    /// <param name="container">the container the egg is being placed in</param>
    public void OnPlaceOnPlate(InteractableBase plate)
    {
        //if the egg is currently shelled, unshell it
        if (sauceState == SauceStates.Loose || sauceState == SauceStates.Scorched)
        {
            ChangeSauceState(SauceStates.Plated);
        }
    }

    public void ChangeSauceState(SauceStates newState)
    {
        sauceState = newState;

        switch (sauceState)
        {
            case SauceStates.Jar:
                imageComponent.sprite = jarImage;
                break;
            case SauceStates.Loose:
                imageComponent.sprite = looseImage;
                GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170); 
                break;
            case SauceStates.Scorched:
                imageComponent.sprite = scorchedImage;
                break;
            case SauceStates.Plated:
                imageComponent.sprite = platedImage;
                break;
            default:
                imageComponent.sprite = looseImage;
                break; 
        }
    }
}
