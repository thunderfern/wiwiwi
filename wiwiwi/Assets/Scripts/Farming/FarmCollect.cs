using UnityEngine;

public class FarmCollect : MonoBehaviour
{
    private InteractMain interaction;
    public GameObject obj;
    public Collectible collectible;

    void Start()
    {
        interaction = GetComponent<InteractMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.instance().addIngredient(collectible);
                //if (World.instance().goal.character == this.character && World.instance().goal.goalType == GoalType.Interact) World.instance().goal.goalComplete();

                obj.SetActive(false);
            }
        }
    }
}
