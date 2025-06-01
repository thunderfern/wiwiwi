using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Player,
    MrMole,
    Narrator,
    Unknown
};

public enum GameState
{
    Dialogue,
    Platformer,
    Cooking,
    Farming,
    Fishing,
    Recipe,
    Inventory
}

public enum GoalType {
    Interact
};

public enum StoryPart {
    Tutorial01,
    Tutorial02,
    Tutorial03
};

public enum Emotion
{
    Neutral,
    Happy,
    Sad,
    Awkward,
    Shocked,
    Thinking,
    Null
}

public enum Collectible
{
    Mushroom,
}

public class Mapper
{
    // Maps

    public Dictionary<string, Character> characterMap;
    public Dictionary<string, GameState> gameStateMap;
    public Dictionary<string, Collectible> objectMap;
    public Dictionary<string, GoalType> goalTypeMap;
    public Dictionary<string, Emotion> emotionMap;

    // Singleton

    private static Mapper _instance;

    private Mapper()
    {
        _instance = this;

        characterMap = new Dictionary<string, Character>()
        {
            { "Player", Character.Player },
            { "Mr. Mole", Character.MrMole },
            { "Narrator", Character.Narrator },
            { "Unknown", Character.Unknown },
        };

        goalTypeMap = new Dictionary<string, GoalType>()
        {
            { "interact", GoalType.Interact }
        };

        emotionMap = new Dictionary<string, Emotion>()
        {
            { "neutral", Emotion.Neutral },
            { "happy", Emotion.Happy },
            { "sad", Emotion.Sad },
            { "awkward", Emotion.Awkward },
            { "shocked", Emotion.Shocked },
            { "thinking", Emotion.Thinking },
            { "null", Emotion.Null }
        };
    }

    public static Mapper instance()
    {
        if (_instance == null)
        {
            Mapper instance = new Mapper();
            _instance = instance;
        }
        return _instance;
    }
}
