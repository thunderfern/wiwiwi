using System.Collections.Generic;
using UnityEngine;



public class StoryManager : MonoBehaviour {

    // Singleton

    private static StoryManager _instance;

    private StoryManager() {
        _instance = this;
    }

    public static StoryManager instance() {
        if (_instance == null) {
            StoryManager instance = new StoryManager();
            _instance = instance;
        }
        return _instance;
    }

    // Fields

    public List<TextAsset> storyFiles;

    public void read(StoryPart storyPart)
    {

        TextAsset parseFile = storyFiles[(int)storyPart];

        World world = World.instance();
        world.prevstate = world.curstate;
        world.curstate = GameState.Dialogue;

        DialogueManager.instance().updateDialogue(JSONParser.parseStory(storyFiles[(int)storyPart]).Item1);

    }
}
