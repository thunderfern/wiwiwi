using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RecipeMain : MonoBehaviour
{

    public GameObject obj;
    public GameObject closeObj;
    public GameObject nextArrow;
    public GameObject prevArrow;
    public GameObject recipe1;
    public GameObject recipe2;
    public GameObject sampleIngredient;
    public TMP_Text soup1Text;
    public TMP_Text soup2Text;
    private ClickMain closeObjClick;
    private ClickMain prevArrowClick;
    private ClickMain nextArrowClick;

    private List<GameObject> recipe1Ingredients;
    private List<GameObject> recipe2Ingredients;

    public List<Sprite> objectSprites;

    public List<Recipe> recipes;
    private int curRecipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curRecipe = 0;
        closeObjClick = new ClickMain(closeObj);
        prevArrowClick = new ClickMain(prevArrow);
        nextArrowClick = new ClickMain(nextArrow);

        recipes = new List<Recipe>();
        this.recipes.Add(new Recipe(new List<Collectible> { Collectible.Potato, Collectible.Clam, Collectible.Basil }, Collectible.ClamChowder));
        this.recipes.Add(new Recipe(new List<Collectible> { Collectible.Carrot, Collectible.Basil }, Collectible.CarrotSoup));
        this.recipes.Add(new Recipe(new List<Collectible> { Collectible.Cod, Collectible.Tomato, Collectible.Potato }, Collectible.FishSoup));
        this.recipes.Add(new Recipe(new List<Collectible> { Collectible.Mushroom, Collectible.Onion }, Collectible.MushroomSoup));
        this.recipes.Add(new Recipe(new List<Collectible> { Collectible.Tomato, Collectible.Onion, Collectible.Basil }, Collectible.TomatoSoup));

        recipe1Ingredients = new List<GameObject>();
        recipe2Ingredients = new List<GameObject>();

        DisplayRecipes();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().curstate != GameState.Recipe)
        {
            obj.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (closeObjClick.hover())
            {
                World.instance().curstate = World.instance().prevstate;
            }
            else if (prevArrowClick.hover())
            {
                if (curRecipe > 0) curRecipe -= 2;
                DisplayRecipes();
            }
            else if (nextArrowClick.hover())
            {
                if (curRecipe + 2 < this.recipes.Count) curRecipe += 2;
                DisplayRecipes();
            }
        }
    }

    void DisplayRecipes()
    {
        for (int i = 0; i < recipe1Ingredients.Count; i++) Destroy(recipe1Ingredients[i]);
        for (int i = 0; i < recipe2Ingredients.Count; i++) Destroy(recipe2Ingredients[i]);
        recipe1Ingredients = new List<GameObject>();
        recipe2Ingredients = new List<GameObject>();
        soup1Text.GetComponent<TMP_Text>().text = "";
        soup2Text.GetComponent<TMP_Text>().text = "";

        soup1Text.GetComponent<TMP_Text>().text = Mapper.instance().collectibleMap2[recipes[curRecipe].soup];
        recipe1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.objectSprites[(int)(recipes[curRecipe].soup)];
        for (int i = 0; i < recipes[curRecipe].ingredients.Count; i++) {
            GameObject tmpIngredient = Instantiate(sampleIngredient, recipe1.transform);
            tmpIngredient.transform.position = recipe1.transform.GetChild(0).transform.position + new Vector3(-1 + i, -2, 0);
            tmpIngredient.GetComponent<SpriteRenderer>().sprite = this.objectSprites[(int)(recipes[curRecipe].ingredients[i])];
            recipe1Ingredients.Add(tmpIngredient);
        }

        if (curRecipe + 1 < this.recipes.Count) {
            soup2Text.GetComponent<TMP_Text>().text = Mapper.instance().collectibleMap2[recipes[curRecipe + 1].soup];
            recipe2.SetActive(true);
            recipe2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.objectSprites[(int)(recipes[curRecipe + 1].soup)];
            for (int i = 0; i < recipes[curRecipe + 1].ingredients.Count; i++) {
                GameObject tmpIngredient = Instantiate(sampleIngredient, recipe2.transform);
                tmpIngredient.transform.position = recipe2.transform.GetChild(0).transform.position + new Vector3(-1 + i, -2, 0);
                tmpIngredient.GetComponent<SpriteRenderer>().sprite = this.objectSprites[(int)(recipes[curRecipe + 1].ingredients[i])];
                recipe2Ingredients.Add(tmpIngredient);
            }
        }
        else {
            recipe2.SetActive(false);
        }
    }
}

public class Recipe
{
    public List<Collectible> ingredients;
    public Collectible soup;

    public Recipe(List<Collectible> ingredients, Collectible soup)
    {
        this.ingredients = ingredients;
        this.soup = soup;
    }
}
