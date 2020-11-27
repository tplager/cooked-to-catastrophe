using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Ben Stern
/// <summary>
/// A component that handles interactions between objects
/// </summary>
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
				Debug.Log(interactions);
			}
			return interactions;
		}
	}

	//Author: Ben Stern
	/// <summary>
	/// List interactions that this object can trigger but cannot handle response to
	/// </summary>
	[SerializeField]protected List<string> interactionsTrigers;

    // Author: John Vance
    /// <summary>
    /// Gets the dropdown menu for multiple interactions
    /// </summary>
    [SerializeField]
    private GameObject interactionDropdown;

    // Author: John Vance
    /// <summary>
    /// Gets the Dropdown component of the dropdown menu
    /// </summary>
    private Dropdown drop;

    private InteractableBase interacting;

    private void Awake()
	{
		interactions = new List<string>();
		interactionsDirty = false;
		actionResponses = new Dictionary<string, InteractDelegate>();

        interactionDropdown = GameObject.Find("InteractionsDropdown");
        //interactionDropdown.SetActive(false); 
        //interactionsTrigers = new List<string>();
    }

	//Author: Ben Stern
	/// <summary>
	/// Add an interaction to this objects list of interactions and responses 
	/// </summary>
	/// <param name="action">The action type that is being added to this list</param>
	/// <param name="interactResponse">The DelegateResponse this action will Have</param>
	public void AddInteractionToList(string actionName, InteractDelegate interactResponse)
	{
		if (actionResponses.ContainsKey(actionName))
		{
			Debug.Log("an action of the same name already exists in the list");
		}
		actionResponses.Add(actionName, interactResponse);
		interactionsDirty = true;
	}

	//Author: Ben Stern
	/// <summary>
	/// Remove an interaction from the list of interactions
	/// </summary>
	/// <param name="actionName">The action type you want to remove from the list</param>
	public void RemoveInteractionFromList(string actionName)
	{
		if (actionResponses.Remove(actionName))
		{
			interactionsDirty = true;
		}
	}

	//Author: Ben Stern
	/// <summary>
	/// add a trigger to this object
	/// </summary>
	/// <param name="triggerName">the trigger to add</param>
	public void AddInteractionTrigger(string triggerName)
	{
		if (!interactionsTrigers.Contains(triggerName))
		{
			interactionsTrigers.Add(triggerName);
		}
	}

	//Author: Ben Stern
	/// <summary>
	/// Remove a trigger from this object
	/// </summary>
	/// <param name="triggerName">the trigger to remove</param>
	public void RemoveInteractionTrigger(string triggerName)
	{
		interactionsTrigers.Remove(triggerName);
	}

	//Author: Ben Stern
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
			if (obj.Interactions.Contains(actionName))
			{
				possibleInteractions.Add(actionName);
			}
		}
		return possibleInteractions;
	}

	//Author: Ben Stern
	/// <summary>
	/// Attempt to trigger interactions on another object 
	/// </summary>
	/// <param name="obj">the object whose interactions we are triggering</param>
	public bool AttemptInteraction(InteractableBase obj)
	{
        interacting = obj;

        List<string> possibleInteractions = GetPossibleInteractions(obj);
		possibleInteractions.AddRange(obj.GetPossibleInteractions(this));
		if(possibleInteractions.Count == 0)
		{
			Debug.Log("NO Interactions, send message to UI");
		}else if(possibleInteractions.Count == 1)
		{
            interactionDropdown.transform.position = this.transform.position + new Vector3(0.0f, 50.0f, 0.0f);
            interactionDropdown.SetActive(true);

            drop = interactionDropdown.GetComponent<Dropdown>();
            drop.ClearOptions();
            possibleInteractions.Insert(0, "None");
            drop.AddOptions(possibleInteractions);

            //obj.Interact(possibleInteractions[0], this);
            //Debug.Log(possibleInteractions[0]);
            return true;
		}

        // Author: John Vance
		else
		{
            // Display dropdown menu and sets it to the second selected object's position
            interactionDropdown.transform.position = this.transform.position + new Vector3(0.0f, 50.0f, 0.0f);
            interactionDropdown.SetActive(true);

            drop = interactionDropdown.GetComponent<Dropdown>();
            drop.ClearOptions();
            possibleInteractions.Insert(0, "None");
            drop.AddOptions(possibleInteractions);

            return true;

            //for (int i = 0; i < possibleInteractions.Count; i++)
            //{
            //    Debug.Log("Interaction list, Send Message to UI \nInteraction " + i + ": " + possibleInteractions[i]);
            //    //Debug.Log(possibleInteractions[i]);

            //}
        }
		return false;
	}

	//Author: Ben Stern
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
		}else if(obj.actionResponses.TryGetValue(action, out response))
		{
			response(this);
		}
	}

    // Author: John Vance
    /// <summary>
    /// Allows for the dropdown menu to run interactions
    /// </summary>
    /// <param name="value"></param>
    public void MultipleInteractions(int value)
    {
        if (interacting != null)
        {
            interacting.Interact(drop.options[value].text, this);
        }

    }

}
