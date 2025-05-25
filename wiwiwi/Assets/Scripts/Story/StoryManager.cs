using System.Collections.Generic;
using UnityEngine;

public enum StoryPart {
    Tutorial01,
    Tutorial02,
    Tutorial03
};

public class StoryManager : MonoBehaviour {

    // Singleton

    public List<TextAsset> storyFiles;

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

    public void read(StoryPart storyPart) {
        DialogueManager.instance().updateDialogue(JSONParser.parseText(storyFiles[(int)storyPart]));
    }
}
