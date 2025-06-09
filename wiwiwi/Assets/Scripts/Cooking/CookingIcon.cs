using UnityEngine;

public class CookingIcon : MonoBehaviour
{

    private InteractMain interaction;
    public GameObject potObj;
    public GameObject cookingObj;
    public GameObject alertInteraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction())
        {
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                potObj.GetComponent<Pot>().resetPot();
                World.instance().prevstate.Insert(0, World.instance().curstate);
                World.instance().curstate = GameState.Cooking;
                cookingObj.SetActive(true);
            }
        }
        else alertInteraction.SetActive(false);
        
    }
}
