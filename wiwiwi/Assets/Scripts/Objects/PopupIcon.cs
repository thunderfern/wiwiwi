using UnityEngine;

public class PopupIcon : MonoBehaviour
{
    private ClickMain clicker;
    public GameObject iconObj;
    public GameObject popupObj;
    public GameState targetGameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        clicker = new ClickMain(iconObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicker.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (World.instance().curstate != GameState.Recipe && World.instance().curstate != GameState.Inventory)
                {

                    World.instance().prevstate.Add(World.instance().curstate);
                }
                World.instance().curstate = targetGameState;
                popupObj.SetActive(true);
            }
        }    
    }
}
