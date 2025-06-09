using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryManager : MonoBehaviour
{

    // Singleton

    private static StoryManager _instance;

    private StoryManager()
    {
        _instance = this;
    }

    public static StoryManager instance()
    {
        if (_instance == null)
        {
            StoryManager instance = new StoryManager();
            _instance = instance;
        }
        return _instance;
    }

    // Fields

    public List<TextAsset> storyFiles;
    public List<GameObject> characterObj;
    public List<GameObject> sittingObj;
    public GameObject boat;
    public GameObject fishing;
    public GameObject moleHome;
    public GameObject platHome;
    public GameObject oppHome;
    public GameObject crate;

    void Start()
    {
        for (int i = 0; i < sittingObj.Count; i++) sittingObj[i].SetActive(false);
        moleHome.SetActive(false);
        platHome.SetActive(false);
        oppHome.SetActive(false);
    }

    public void read(StoryPart storyPart)
    {


        TextAsset parseFile = storyFiles[(int)storyPart];

        World world = World.instance();
        world.prevstate.Insert(0, world.curstate);
        world.curstate = GameState.Dialogue;

        (List<DialogueScreen>, Goal, List<Setup>) parseResult = JSONParser.parseStory(storyFiles[(int)storyPart]);
        DialogueManager.instance().updateDialogue(parseResult.Item1, parseResult.Item3);
        World.instance().goal = parseResult.Item2;
        Debug.Log(World.instance().goal.character);
        Debug.Log(World.instance().goal.goalType);
    }

}
