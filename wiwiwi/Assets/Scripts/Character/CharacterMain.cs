using UnityEngine;

public class CharacterMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private InteractMain interaction;
    public GameObject obj;
    public Character character;
    public GameObject alertInteraction;

    void Awake()
    {
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction())
        {
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (World.instance().goal.character == this.character && World.instance().goal.goalType == GoalType.Interact) World.instance().goal.goalComplete();
            }
        }
        else
        {
            alertInteraction.SetActive(false);
        }

    }

}
