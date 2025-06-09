using UnityEngine;

public class CrateMain : MonoBehaviour
{

    public GameObject opp;
    public GameObject obj;
    private InteractMain interaction;
    public StoryPart storyPart;
    public GameObject alertInteraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().goal.goalType == GoalType.Null && !World.instance().unlockOpossum) interaction.interactable = true;
        else interaction.interactable = false;
        if (interaction.allowInteraction())
        {
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StoryManager.instance().read(storyPart);
                opp.SetActive(true);
                obj.SetActive(false);
            }
        }
        else
        {
            alertInteraction.SetActive(false);
        }
    }
}
