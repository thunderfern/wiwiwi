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
        goalType = Mapper.instance().goalTypeMap[a];
        if (goalType == GoalType.Interact)
        {
            character = Mapper.instance().characterMap[b];
        }
        else if (goalType == GoalType.Go)
        {
            location = Mapper.instance().locationMap[b];
        }
        else if (goalType == GoalType.Collect)
        {
            collectible = Mapper.instance().collectibleMap[b];
        }
        else if (goalType == GoalType.Open)
        {
            icon = Mapper.instance().iconMap[b];
        }
        nextAction = (StoryPart)Enum.Parse(typeof(StoryPart), c);
    }

    public void goalComplete()
    {
        Debug.Log("slacker\n");
        StoryManager.instance().read(nextAction);
    }

    
}
