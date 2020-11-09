using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Ben Stern
/// <summary>
/// A singleton that represents the cart, is not destroyed when a new scene is loaded
/// </summary>
public class CartManager : MonoBehaviour
{

	private Dictionary<CartItem,int> ItemsInCart;
	[SerializeField] private int MaxCartSpace = 50;
	private int UsedCartSpace;

	private static CartManager _instance;


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
		if(_instance != null || _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public bool AddItemToCart(CartItem item)
	{
		if(UsedCartSpace + item.Size > MaxCartSpace)
		{
			Debug.Log("Not Enough Space");
			return false;
		}
		
		ItemsInCart[item] += 1;
		UsedCartSpace += item.Size;
		return true;
	}

	public bool RemoveItemFromCart(CartItem item)
	{
		if(ItemsInCart.ContainsKey(item) || ItemsInCart[item] <= 0)
		{
			Debug.Log("Item Not in Cart");
			return false;
		}

		ItemsInCart[item] -= 1;
		UsedCartSpace -= item.Size;
		return true;
	}

}
