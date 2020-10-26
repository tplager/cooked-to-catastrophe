using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableBase))]
public class ContainerComponent : MonoBehaviour
{

	public Vector3 PlacePositionRelative;

	/// <summary>
	/// The containers interactable component
	/// </summary>
	private InteractableBase interactableComponent;

	//May want to make this a list in the future
	/// <summary>
	/// A refrence to the item that this container is holding
	/// </summary>
	private InteractableBase itemHolding;

	private void Start()
	{
		//initialize all of the interactions and triggers
		interactableComponent = GetComponent<InteractableBase>();
		interactableComponent.AddInteractionToList("Place Item", HoldItem);
		interactableComponent.AddInteractionTrigger("Empty into");
	}


	//author: Ben Stern
	/// <summary>
	/// Place an item into this container
	/// </summary>
	/// <param name="ItemToHold">The item to place into the container</param>
	public void HoldItem(InteractableBase ItemToHold)
	{
		itemHolding = ItemToHold;
		itemHolding.transform.position = transform.position + PlacePositionRelative;
		itemHolding.transform.SetParent(transform);
		itemHolding.Interact("On Place In Container", interactableComponent);
		itemHolding.GetComponent<SelectableObject>().enabled = false;
		//add the empty interactions to the list
		interactableComponent.AddInteractionToList("Empty into", EmptyInto);
	}

	//Author: Ben Stern
	/// <summary>
	/// Attempt to empty the item in this container into something else
	/// </summary>
	/// <param name="itemToEmptyInto">an interactable Item containing</param>
	public void EmptyInto(InteractableBase itemToEmptyInto)
	{
		itemToEmptyInto.Interact("Place Item", itemHolding);
		//double check that the item is no longer in this container befor editing properties.
		if (itemHolding.transform.parent != transform)
		{
			itemHolding = null;
			interactableComponent.RemoveInteractionFromList("Empty into");
		}
	}
}
