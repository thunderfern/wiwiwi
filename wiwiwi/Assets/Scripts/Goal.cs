using UnityEngine;

public enum GoalType {
    Interact
};

public class Goal {

    public GoalType goalType;
    public Character character;
    public bool goalComplete;
    public string nextAction;

    public Goal() {
        goalType = GoalType.Interact;
        character = Character.MrMole;
        goalComplete = false;
    }
    
}
