using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class World : MonoBehaviour {
    
    // Singleton

    private static World _instance;

    private World() {
        _instance = this;
    }

    public static World instance() {
        if (_instance == null) {
            World instance = new World();
            _instance = instance;
        }
        return _instance;
    }

    public GameState curstate;
    public GameState prevstate;
    public Goal goal;
    public StoryManager storyManager;
    public DialogueManager dialogueManager;

    void Start() {
        this.curstate = GameState.Platformer;
        this.goal = new Goal();
        this.storyManager = StoryManager.instance();
        this.dialogueManager = DialogueManager.instance();
        this.storyManager.read(StoryPart.Tutorial01);
    }

    public void changeGoal() {
        this.curstate = GameState.Dialogue;
        //storyManager.read(currentGoal.nextAction);
    }

}
