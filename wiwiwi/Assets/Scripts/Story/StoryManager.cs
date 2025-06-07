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
        Debug.Log(storyPart);
        TextAsset parseFile = storyFiles[(int)storyPart];

        World world = World.instance();
        world.prevstate.Add(world.curstate);
        world.curstate = GameState.Dialogue;

        (List<DialogueScreen>, Goal) parseResult = JSONParser.parseStory(storyFiles[(int)storyPart]);
        DialogueManager.instance().updateDialogue(parseResult.Item1);
        World.instance().goal = parseResult.Item2;
        Debug.Log(World.instance().goal.character);
        Debug.Log(World.instance().goal.goalType);
        

    }
}
