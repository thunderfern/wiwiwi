using UnityEngine;
using System;

public class Goal
{

    public GoalType goalType;
    public Character character;
    public Collectible collectible;
    public Icon icon;
    public Location location;
    public StoryPart nextAction;

    public Goal() { }

    public Goal(string a, string b, string c)
    {
        for (int i = 1; i < 4; i++)
        {
            StoryManager.instance().characterObj[i].GetComponent<InteractMain>().interactable = false;
        }
        goalType = (GoalType)Enum.Parse(typeof(GoalType), a);
        if (goalType == GoalType.Interact)
        {
            character = Mapper.instance().characterMap[b];
            StoryManager.instance().characterObj[(int)character].GetComponent<InteractMain>().interactable = true;
        }
        else if (goalType == GoalType.Go)
        {
            location = (Location)Enum.Parse(typeof(Location), b);
        }
        else if (goalType == GoalType.Collect)
        {
            collectible = (Collectible)Enum.Parse(typeof(Collectible), b);
        }
        else if (goalType == GoalType.Open)
        {
            icon = (Icon)Enum.Parse(typeof(Icon), b);
        }
        nextAction = (StoryPart)Enum.Parse(typeof(StoryPart), c);
    }

    public void goalComplete()
    {
        StoryManager.instance().read(nextAction);
    }

    
}
