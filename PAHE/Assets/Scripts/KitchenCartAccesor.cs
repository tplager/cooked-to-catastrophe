using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenCartAccesor : MonoBehaviour
{

	public GameObject CartMenueItem;

	public GameObject canvas;

	public Vector3 defaultPosition;

    public void AddInventoryItemToScene(CartItem item, int number)
	{
		if (number > 0)
		{
			GameObject obj = Instantiate(CartMenueItem, transform);
			obj.GetComponentsInChildren<Image>()[1].sprite = item.CartImage;
			obj.GetComponentInChildren<Text>().text = number.ToString();
			obj.GetComponent<Button>().onClick.AddListener(() => { CreateInventoryItem(item, obj); });
		}
	}


	public void CreateInventoryItem(CartItem item, GameObject obj)
	{
		int numInCart = CartManager.Instance.GetNumberInShopingCart(item);
		if (numInCart <= 0)
		{
			Destroy(obj);
			return;
		}

		GameObject CartItem = Instantiate(item.prefab, canvas.transform);
		CartItem.transform.localPosition = defaultPosition;
		CartItem.transform.localScale = Vector3.one;
		CartManager.Instance.RemoveItemFromCart(item);
		numInCart--;
		if (numInCart <= 0)
		{
			Destroy(obj);
			return;
		}

		obj.GetComponentInChildren<Text>().text = numInCart.ToString();
	}

}
