using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CookbookUI : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Cookbook cookbook;

    [SerializeField]
    private int currentRecipeIndex = 0;

    [SerializeField]
    private Text recipeTitle;

    [SerializeField]
    private GameObject ingredientsPanel;

    [SerializeField]
    private GameObject instructionsPanel;

    [SerializeField]
    private GameObject ingredientsPrefab;

    [SerializeField]
    private GameObject instructionsPrefab;

    [SerializeField]
    private GameObject content;

    [SerializeField]
    private GameObject isSpecialIndicator;

    [SerializeField]
    private List<string> specials = new List<string>();

    [SerializeField]
    private Text orderQuantity; 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        specials.Add(cookbook.recipes[Random.Range(0, cookbook.recipes.Length)].name);

        UpdateCookbookDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextRecipe()
    {
        if (currentRecipeIndex + 1 < cookbook.recipes.Length && cookbook.recipes[currentRecipeIndex + 1].unlocked)
        {
            currentRecipeIndex++;
            UpdateCookbookDisplay();
        }
        else
        {
            Debug.Log("No more unlocked recipes."); 
        }
    }

    public void PreviousRecipe()
    {
        if (currentRecipeIndex > 0)
        {
            currentRecipeIndex--;
            UpdateCookbookDisplay();
        }
        else
        {
            Debug.Log("You have reached the first page.");
        }
    }

    public void UpdateCookbookDisplay()
    {
        recipeTitle.text = cookbook.recipes[currentRecipeIndex].name; 
        
        isSpecialIndicator.SetActive(specials.Contains(cookbook.recipes[currentRecipeIndex].name));
        orderQuantity.text = $"x{Random.Range(0, 5)}"; 

        for (int i = 0; i < cookbook.recipes[currentRecipeIndex].ingredients.Length; i++)
        {
            string ingredient = cookbook.recipes[currentRecipeIndex].ingredients[i];
            try
            {
                GameObject ingredientObject = ingredientsPanel.transform.GetChild(i + 1).gameObject;
                ingredientObject.SetActive(true);
                ingredientObject.name = ingredient;
                ingredientObject.GetComponentInChildren<Text>().text = ingredient;
            }
            catch
            {
                GameObject ingredientObject = Instantiate(ingredientsPrefab, ingredientsPanel.transform);
                ingredientObject.name = ingredient;
                ingredientObject.GetComponentInChildren<Text>().text = ingredient;
            }
        }

        if (ingredientsPanel.transform.childCount - 1 > cookbook.recipes[currentRecipeIndex].ingredients.Length)
        {
            for (int i = cookbook.recipes[currentRecipeIndex].ingredients.Length + 1; i < ingredientsPanel.transform.childCount; i++)
            {
                ingredientsPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < cookbook.recipes[currentRecipeIndex].instructions.Length; i++)
        {
            string instruction = cookbook.recipes[currentRecipeIndex].instructions[i];
            try
            {
                GameObject instructionObject = instructionsPanel.transform.GetChild(i + 1).gameObject;
                instructionObject.SetActive(true);
                instructionObject.name = instruction;
                instructionObject.GetComponentInChildren<Text>().text = instruction;
            }
            catch
            {
                GameObject instructionObject = Instantiate(instructionsPrefab, instructionsPanel.transform);
                instructionObject.name = instruction;
                instructionObject.GetComponentInChildren<Text>().text = instruction;
            }
        }

        if (instructionsPanel.transform.childCount - 1 > cookbook.recipes[currentRecipeIndex].instructions.Length)
        {
            for (int i = cookbook.recipes[currentRecipeIndex].instructions.Length + 1; i < instructionsPanel.transform.childCount; i++)
            {
                instructionsPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
