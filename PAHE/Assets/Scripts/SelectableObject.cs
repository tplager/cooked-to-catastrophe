using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public bool selected;
    public KitchenManager kitchenManager;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        kitchenManager = GameObject.Find("MainCamera").GetComponent<KitchenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // Highlight object if selected
        if (selected == true)
        {
            //TODO: Highlight object edges
        }
    }

    // Object is selected when clicked
    private void OnMouseDown()
    {
        // Only select this object if another object is not already selected
        if (kitchenManager.currentSelection == null)
        {
            selected = true;
            kitchenManager.currentSelection = this.gameObject;
        }
    }
}
