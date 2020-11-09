﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Ben Stern
/// <summary>
/// A singleton that represents the cart, is not destroyed when a new scene is loaded
/// </summary>
public class CartManager : MonoBehaviour
{

	//was orignally a dictionary of cartitems to ints, had to change it while fixing a bug, may change it back
	/// <summary>
	/// A dictionary of items in the cart, uses the items name as the key and holds a game object and int tuple as a value
	/// </summary>
	private Dictionary<string,(GameObject, int)> itemsInCart;
	/// <summary>
	/// a representation of the maximum space in the cart
	/// </summary>
	public int MaxCartSpace = 50;
	/// <summary>
	/// a representation of the used space in the cart
	/// </summary>
	private int usedCartSpace;

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
		itemsInCart = new Dictionary<string, (GameObject, int)>();
	}

	//Author: Ben Stern
	/// <summary>
	/// Attempts to add an item to the cart
	/// </summary>
	/// <param name="item">The Item being added to the cart</param>
	/// <returns>True if the item was added to the cart, false other wise</returns>
	public bool AddItemToCart(CartItem item)
	{
		if(usedCartSpace + item.Size > MaxCartSpace)
		{
			Debug.Log("Not Enough Space");
			return false;
		}

		if (!itemsInCart.ContainsKey(item.name))
		{
			itemsInCart[item.name] = (item.gameObject,0);
		}

		itemsInCart[item.name] = (itemsInCart[item.name].Item1, itemsInCart[item.name].Item2 + 1);
		usedCartSpace += item.Size;
		Debug.Log(item.name + ": " + itemsInCart[item.name]);
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
		if(!itemsInCart.ContainsKey(item.name) || itemsInCart[item.name].Item2 <= 0)
		{
			Debug.Log("Item Not in Cart");
			return false;
		}

		itemsInCart[item.name] = (itemsInCart[item.name].Item1, itemsInCart[item.name].Item2 - 1);
		usedCartSpace -= item.Size;
		Debug.Log(item.name + ": " + itemsInCart[item.name]);
		return true;
	}

}
