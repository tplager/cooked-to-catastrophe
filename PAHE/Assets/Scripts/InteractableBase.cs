using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
	/// <summary>
	/// A delegate that represents actions between interactable objects
	/// </summary>
	public delegate void InteractDelegate(InteractableBase interactable);

	/// <summary>
	/// A dictionary of interactions, and their responses, that this object has
	/// </summary>
	private Dictionary<string, InteractDelegate> actionResponses;
	private bool interactionsDirty;

	private List<string> interactions;
	/// <summary>
	/// The interactions that this object is capapble of
	/// </summary>
	public List<string> Interactions
	{
		get
		{
			if (interactionsDirty)
			{
				interactions.Clear();
				interactions.AddRange(actionResponses.Keys);
			}
			return interactions;
		}
	}

	/// <summary>
	/// List interactions that this object can trigger but cannot handle response to
	/// </summary>
	[SerializeField]protected List<string> interactionsTrigers;

	/// <summary>
	/// Add an interaction to this objects list of interactions and responses
	/// </summary>
	/// <param name="action">The action type that is being added to this list</param>
	/// <param name="interactResponse">The DelegateResponse this action will Have</param>
	protected void AddInteractionToList(string actionName, InteractDelegate interactResponse)
	{
		actionResponses.Add(actionName, interactResponse);
		interactionsDirty = true;
	}

	/// <summary>
	/// Get the list of possible actions this object can trigger
	/// </summary>
	/// <param name="obj">The object we are trying to trigger interactions on</param>
	/// <returns></returns>
	public List<string> GetPossibleInteractions(InteractableBase obj)
	{
		List<string> possibleInteractions = new List<string>();
		foreach(string actionName in interactionsTrigers)
		{
			if (obj.interactions.Contains(actionName))
			{
				possibleInteractions.Add(actionName);
			}
		}
		return possibleInteractions;
	}

	/// <summary>
	/// Attempt to trigger interactions on another object 
	/// </summary>
	/// <param name="obj">the object whose interactions we are triggering</param>
	public void AttemptInteraction(InteractableBase obj)
	{
		List<string> possibleInteractions = GetPossibleInteractions(obj);
		if(possibleInteractions.Count == 0)
		{
			Debug.Log("NO Interactions, send message to UI");
		}else if(possibleInteractions.Count == 1)
		{
			obj.Interact(possibleInteractions[0], this);
		}
		else
		{
			Debug.Log("Interaction list, Send Message to UI");
		}
	}

	/// <summary>
	/// trigger an interaction on this object
	/// </summary>
	/// <param name="action">the interaction that is being triggered</param>
	/// <param name="obj">the object that is triggering it</param>
	public void Interact(string action, InteractableBase obj)
	{
		InteractDelegate response;
		if (actionResponses.TryGetValue(action, out response))
		{
			response(obj);
		}
	}

}
