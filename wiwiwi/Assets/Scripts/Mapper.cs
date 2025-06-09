using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Player,
    Mole,
    Platypus,
    Opossum,
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
    Inventory,
    Boating
}

public enum GoalType
{
    Interact,
    Go,
    Collect,
    Open,
    Null
};

public enum Icon
{
    Recipe,
    Inventory
}

public enum StoryPart
{
    Tutorial01,
    Tutorial02,
    Tutorial03,
    Tutorial04,
    Tutorial05,
    Tutorial06,
    Tutorial07,
    Tutorial08,
    Tutorial09,
    Tutorial10,
    Tutorial11,
    Tutorial12,
    Platypus01,
    Platypus02,
    Platypus03,
    Platypus04,
    Platypus05,
    Platypus06,
    Platypus07,
    Platypus08,
    Opossum01,
    Opossum02,
    Opossum03,
    Opossum04,
    Opossum05,
    Opossum06,
    Opossum07,
    Opossum08,
    Opossum09,
    Opossum10,
    Null
};

public enum Emotion
{
    Neutral,
    Happy,
    Sad,
    Awkward,
    Shocked,
    Thinking,
    Embarrassed,
    Drowsy,
    Scared,
    Shy,
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

public enum Location
{
    Burrow,
    Kitchen,
    Garden,
    DiningRoom,
    Forest,
    DinnerTable,
    Pond
}

public enum AudioType
{
    Footsteps,
    Click,
    Rain,
    Jumping,
    Splash,
    Pond,
    OpenDoor,
    PageFlip,
    LandingOnGrass,
    LandingOnDirt,
    Cooking,
    WateringPlants,
    Knock,
    GibberishMole,
    GibberishPlatypus,
    GibberishOpossum,
    GibberishPlayer,
    RainThunder,
    Null
}

public enum BackgroundMusic
{
    BurrowBackground,
    OverworldBackground,
    RainBackground,
    ThunderBackground
}


public class Mapper
{
    // Maps

    public Dictionary<string, Character> characterMap;
    public Dictionary<string, Location> locationMap;
    public Dictionary<string, GameState> gameStateMap;
    public Dictionary<string, Collectible> collectibleMap;
    public Dictionary<string, Icon> iconMap;
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
            { "Mr. Mole", Character.Mole },
            { "Mr. Platypus", Character.Platypus },
            { "Opossum", Character.Opossum },
            { "Narrator", Character.Narrator },
            { "Unknown", Character.Unknown },
        };

        locationMap = new Dictionary<string, Location>()
        {
            { "burrow", Location.Burrow },
            { "kitchen", Location.Kitchen },
            { "garden", Location.Garden }
        };

        iconMap = new Dictionary<string, Icon>()
        {
            { "recipe", Icon.Recipe },
            { "inventory", Icon.Inventory }
        };

        goalTypeMap = new Dictionary<string, GoalType>()
        {
            { "interact", GoalType.Interact },
            { "go", GoalType.Go },
            { "collect", GoalType.Collect },
            { "open", GoalType.Open }
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

        collectibleMap = new Dictionary<string, Collectible>()
        {
            { "Basil", Collectible.Basil },
            { "Carrot", Collectible.Carrot },
            { "Clam", Collectible.Clam },
            { "Cod", Collectible.Cod },
            { "Mushroom", Collectible.Mushroom },
            { "Onion", Collectible.Onion },
            { "Potato", Collectible.Potato },
            { "Tomato", Collectible.Tomato },
            { "CarrotSoup", Collectible.CarrotSoup },
            { "ClamChowder", Collectible.ClamChowder },
            { "FishSoup", Collectible.FishSoup },
            { "MushroomSoup", Collectible.MushroomSoup },
            { "TomatoSoup", Collectible.TomatoSoup },
            { "UnknownSoup", Collectible.UnknownSoup },
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
