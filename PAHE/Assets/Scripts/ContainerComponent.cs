using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableBase))]
public class ContainerComponent : MonoBehaviour
{

	private InteractableBase interactableComponent;

	private InteractableBase itemHolding;

	private void Start()
	{
		interactableComponent = GetComponent<InteractableBase>();
		interactableComponent.AddInteractionToList("Place Item", HoldItem);
	}

	public void HoldItem(InteractableBase ItemToHold)
	{
		itemHolding = ItemToHold;
		itemHolding.transform.position = transform.position - new Vector3(0,30,0);
		itemHolding.transform.SetParent(transform);
		itemHolding.GetComponent<SelectableObject>().enabled = false;
	}
}
