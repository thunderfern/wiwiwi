using UnityEngine;

public class PlatMain : MonoBehaviour
{
    public GameObject obj;
    private InteractMain interaction;
    public StoryPart storyPart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().goal.goalType == GoalType.Null && World.instance().unlockPlatypus == false)
        {
            interaction.interactable = true;
        }
        else if (World.instance().goal.goalType == GoalType.Null)
        {
            interaction.interactable = false;
        }
        if (interaction.allowInteraction())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StoryManager.instance().read(storyPart);
            }
        }
    }
}
