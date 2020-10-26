using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Author: Ben Stern


public enum EggStates
{
	shelled,
	raw,
	Fried,
}

[RequireComponent(typeof(InteractableBase))]
[RequireComponent(typeof(Image))]
public class EggScript : MonoBehaviour
{

	private InteractableBase interactableComponent;
	private Image imageComponent;
	private EggStates eggState;

	public Sprite shelledImage;

	public Sprite rawImage;

	public Sprite Fried;

    void Start()
    {
		interactableComponent = GetComponent<InteractableBase>();
		interactableComponent.AddInteractionToList("On Place In Container", OnPlaceInContainer);
		imageComponent = GetComponent<Image>();
		imageComponent.sprite = shelledImage;
    }

	public void OnPlaceInContainer(InteractableBase container)
	{
		if(eggState == EggStates.shelled)
		{
			eggState = EggStates.raw;
			imageComponent.sprite = rawImage;
		}
	}

}
