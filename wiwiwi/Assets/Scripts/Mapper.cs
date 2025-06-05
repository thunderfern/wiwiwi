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
    Basil,
    Carrot,
    Clam,
    Cod,
    Mushroom,
    Onion,
    Potato,
    Tomato,
    CarrotSoup,
    ClamChowder,
    FishSoup,
    MushroomSoup,
    TomatoSoup,
    UnknownSoup
}

public enum AudioType
{
    Knock,
    FootSteps
}

public enum BackgroundMusic
{
    HappyOne
}


public class Mapper
{
    // Maps

    public Dictionary<string, Character> characterMap;
    public Dictionary<string, GameState> gameStateMap;
    public Dictionary<string, Collectible> objectMap;
    public Dictionary<string, GoalType> goalTypeMap;
    public Dictionary<string, Emotion> emotionMap;
    public Dictionary<Collectible, string> collectibleMap2;

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

        collectibleMap2 = new Dictionary<Collectible, string>()
        {
            { Collectible.Basil , "Basil" },
            { Collectible.Carrot , "Carrot" },
            { Collectible.Clam , "Clam" },
            { Collectible.Cod , "Cod" },
            { Collectible.Mushroom , "Mushroom" },
            { Collectible.Onion , "Onion" },
            { Collectible.Potato , "Potato" },
            { Collectible.Tomato , "Tomato" },
            { Collectible.CarrotSoup , "Carrot Soup" },
            { Collectible.ClamChowder , "Clam Chowder" },
            { Collectible.FishSoup , "Fish Soup" },
            { Collectible.MushroomSoup , "Mushroom Soup" },
            { Collectible.TomatoSoup , "Tomato Soup" },
            { Collectible.UnknownSoup , "Unknown Soup" }
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
