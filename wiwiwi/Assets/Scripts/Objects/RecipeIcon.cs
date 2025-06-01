using UnityEngine;

public class RecipeIcon : MonoBehaviour
{
    private ClickMain clicker;
    public GameObject obj;
    public GameObject recipeObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        clicker = new ClickMain(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicker.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (World.instance().curstate != GameState.Recipe && World.instance().curstate != GameState.Inventory) World.instance().prevstate = World.instance().curstate;
                World.instance().curstate = GameState.Recipe;
                recipeObj.SetActive(true);
            }
        }    
    }
}
