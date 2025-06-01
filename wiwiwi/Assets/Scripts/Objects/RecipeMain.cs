using System.Collections.Generic;
using UnityEngine;

public class RecipeMain : MonoBehaviour {

    public GameObject obj;
    public GameObject closeObj;
    private ClickMain closeObjClick;

    public List<Recipe> recipes;
    private int curRecipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curRecipe = 1;
        closeObjClick = new ClickMain(closeObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().curstate != GameState.Recipe)
        {
            obj.SetActive(false);
        }
        if (closeObjClick.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                World.instance().curstate = World.instance().prevstate;
            }
        }
        
    }
}

public class Recipe
{
    List<Collectible> ingredients;
    Collectible soup;
}
