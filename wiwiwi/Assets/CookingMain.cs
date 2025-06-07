using UnityEngine;
using System;

public class CookingMain : MonoBehaviour
{

    public GameObject obj;
    public GameObject exitObj;
    public GameObject cookingObj;
    public GameObject pot;
    public ClickMain exitObjInteract;
    public ClickMain cookingObjInteract;
    public bool cooking;
    private float waitingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooking = true;
        waitingTime = 0;
        exitObjInteract = new ClickMain(exitObj);
        cookingObjInteract = new ClickMain(cookingObj);
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().curstate != GameState.Cooking) obj.SetActive(false);
        if (Input.GetMouseButtonDown(0) && cooking)
        {
            if (exitObjInteract.hover())
            {
                World.instance().curstate = World.instance().prevstate[0];
                World.instance().prevstate.RemoveAt(0);
            }
            else if (cookingObjInteract.hover())
            {
                cooking = false;
            }
        }
        else if (!cooking)
        {
            waitingTime += Time.deltaTime;
            if (waitingTime > 3)
            {
                string tmpsoup = pot.GetComponent<Pot>().soupSearch();
                cooking = true;
                World.instance().curstate = World.instance().prevstate[0];
                World.instance().prevstate.RemoveAt(0);
                if (tmpsoup != "Nothing") Inventory.instance().addIngredient((Collectible)Enum.Parse(typeof(Collectible), tmpsoup));
            }
        }
    }
}
