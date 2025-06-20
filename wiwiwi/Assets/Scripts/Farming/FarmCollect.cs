using UnityEngine;
using System.Collections.Generic;

public class FarmCollect : MonoBehaviour
{
    private InteractMain interaction;
    public GameObject obj;
    public Collectible collectible;
    public List<Sprite> spriteList;
    public GameObject alertInteraction;

    void Start()
    {
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (collectible == Collectible.Basil) obj.GetComponent<SpriteRenderer>().sprite = spriteList[0];
        if (collectible == Collectible.Onion) obj.GetComponent<SpriteRenderer>().sprite = spriteList[1];
        if (collectible == Collectible.Carrot) obj.GetComponent<SpriteRenderer>().sprite = spriteList[2];
        if (collectible == Collectible.Potato) obj.GetComponent<SpriteRenderer>().sprite = spriteList[3];
        if (interaction.allowInteraction())
        {
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.instance().addIngredient(collectible);
                AudioManager.instance().StopSound(AudioType.WateringPlants);
                //if (World.instance().goal.character == this.character && World.instance().goal.goalType == GoalType.Interact) World.instance().goal.goalComplete();

                obj.SetActive(false);
            }
        }
        else alertInteraction.SetActive(false);
    }
}
