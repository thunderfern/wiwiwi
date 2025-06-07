using UnityEngine;

public class LocationMain : MonoBehaviour
{
    public Location location;
    private InteractMain interaction;
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
            if (World.instance().goal.goalType == GoalType.Go && World.instance().goal.location == location) World.instance().goal.goalComplete();
        }
    }
}
