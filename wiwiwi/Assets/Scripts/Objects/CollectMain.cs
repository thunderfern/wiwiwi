using UnityEngine;

public class CollectMain : MonoBehaviour
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
                CollectibleManager.instance().reset(transform.GetSiblingIndex());
                //if (World.instance().goal.character == this.character && World.instance().goal.goalType == GoalType.Interact) World.instance().goal.goalComplete();

                obj.SetActive(false);
            }
        }
    }
}
