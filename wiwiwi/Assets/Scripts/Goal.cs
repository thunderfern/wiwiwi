using UnityEngine;

public class Goal
{

    public GoalType goalType;
    public Character character;
    public string nextAction;

    public Goal()
    {
        goalType = GoalType.Interact;
        character = Character.MrMole;
    }
    
    public void goalComplete()
    {
        Debug.Log("yas\n");
    }
    
}
