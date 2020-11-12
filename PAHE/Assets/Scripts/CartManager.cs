using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// Author: Ben Stern
/// <summary>
/// A singleton that represents the cart, is not destroyed when a new scene is loaded
/// </summary>
public class CartManager : MonoBehaviour
{

	/// <summary>
	/// A dictionary of items in the cart, uses a cart object as a key and an int as a value
	/// </summary>
	private Dictionary<CartItem, int> itemsInCart;

	//private Dictionary<string,(GameObject, int)> itemsInCart;
	/// <summary>
	/// a representation of the maximum space in the cart
	/// </summary>
	public int MaxCartSpace = 50;

	/// <summary>
	/// a representation of the used space in the cart
	/// </summary>
	private int usedCartSpace;

	/// <summary>
	/// The shoping cart list in the scene
	/// </summary>
	private Text ShopingCartList;

	/// <summary>
	/// the singleton instance
	/// </summary>
	private static CartManager _instance;

	/// <summary>
	/// the instance of the cart manager
	/// </summary>
	public static CartManager Instance
	{
		get
		{
			if(_instance == null)
			{
				GameObject obj = new GameObject("CartManager");
				_instance = obj.AddComponent<CartManager>();
			}
			return _instance;
		}
	}

	//Im using Awake here because it is called before start
	private void Awake()
	{
		if(_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad(gameObject);
		//itemsInCart = new Dictionary<string, (GameObject, int)>();
		itemsInCart = new Dictionary<CartItem, int>();
		//because cart manager is not destroyed when new scenes are loaded we need to reget certain elements when entering a new scene
		SceneManager.sceneLoaded += OnSceneLoaded;
		//I dont like doing this, but I want to get this done quickly so im doing it like this
		GameObject obj = GameObject.Find("/OverviewCanvas/Grocery List/Text");
		if (obj != null)
		{
			ShopingCartList = obj.GetComponent<Text>();
		}
	}

	//Author: Ben Stern
	/// <summary>
	/// Attempts to add an item to the cart
	/// </summary>
	/// <param name="item">The Item being added to the cart</param>
	/// <returns>True if the item was added to the cart, false other wise</returns>
	public bool AddItemToCart(CartItem item)
	{
		if (usedCartSpace + item.Size > MaxCartSpace)
		{
			//Debug.Log("Not Enough Space");
			return false;
		}

		if (!itemsInCart.ContainsKey(item))
		{
			itemsInCart[item] = 0;
		}

		itemsInCart[item] += 1;
		usedCartSpace += item.Size;
		//Debug.Log(item.name + ": " + itemsInCart[item]);
		UpdateCartList();
		return true;
	}


	//Author: Ben Stern
	/// <summary>
	/// attempts ot remove an item from the cart
	/// </summary>
	/// <param name="item">the item being removed from the cart</param>
	/// <returns>true if the item was removed from the cart, false other wise</returns>
	public bool RemoveItemFromCart(CartItem item)
	{
		if (!itemsInCart.ContainsKey(item) || itemsInCart[item] <= 0)
		{
			//Debug.Log("Item Not in Cart");
			return false;
		}

		itemsInCart[item] -= 1;
		usedCartSpace -= item.Size;
		//Debug.Log(item.name + ": " + itemsInCart[item]);
		UpdateCartList();
		return true;
	}

	/// <summary>
	/// Update the cart list when done
	/// </summary>
	public void UpdateCartList()
	{
		if(ShopingCartList != null)
		{
			string s = "";
			foreach(KeyValuePair<CartItem, int> item in itemsInCart)
			{
				if(item.Value > 0)
				{
					s += item.Key.ItemName;
					s += "  X";
					s += item.Value;
					s += '\n';
				}
			}
			ShopingCartList.text = s;
		}
	}

	// Author: Ben Stern
	/// <summary>
	/// Is  called when a new scene is loaded
	/// </summary>
	/// <param name="scene">the scene being loaded</param>
	/// <param name="mode">the way the scene is being loaded</param>
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ShopingCartList = null;
		if(scene.name == "Pantry")
		{
			//I dont like doing this, but I want to get this done quickly so im doing it like this
			GameObject obj = GameObject.Find("/OverviewCanvas/Grocery List/Text");
			if (obj != null)
			{
				ShopingCartList = obj.GetComponent<Text>();
			}
		}
	}

	private void OnDisable()
	{
		//remove from scene manager when the program is closed
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
