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

    public void read(StoryPart storyPart)
    {
        Debug.Log(storyPart);
        TextAsset parseFile = storyFiles[(int)storyPart];

        World world = World.instance();
        world.prevstate.Insert(0, world.curstate);
        world.curstate = GameState.Dialogue;

        (List<DialogueScreen>, Goal) parseResult = JSONParser.parseStory(storyFiles[(int)storyPart]);
        DialogueManager.instance().updateDialogue(parseResult.Item1);
        World.instance().goal = parseResult.Item2;
        Debug.Log(World.instance().goal.character);
        Debug.Log(World.instance().goal.goalType);
    }

    public void parseSetup(string arg1, string arg2, string arg3)
    {
        if (arg1 == "position")
        {
            Character curchar = (Character)Enum.Parse(typeof(Character), arg2);
            if (arg3 == "kitchen")
            {
                //arg2.transform.position = new Vector3(0f, 0f, arg2.transform.position.z);
            }
            else if (arg3 == "table")
            {
                if (curchar == Character.MrMole)
                {

                }
            }
        }
        else if (arg1 == "unlock")
        {
            if (arg2 == "Platypus")
            {

            }
        }
        else if (arg1 == "take")
        {
            // arg2 is collectible
        }
        else if (arg1 == "fish")
        {
            //set fish
        }
    }
}
