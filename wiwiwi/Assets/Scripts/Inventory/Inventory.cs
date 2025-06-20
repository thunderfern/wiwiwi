using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Singleton

    private static Inventory _instance;

    private Inventory()
    {
        _instance = this;
        ingredients = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            ingredients.Add(0);
        }
    }

    public static Inventory instance()
    {
        if (_instance == null)
        {
            Inventory instance = new Inventory();
            _instance = instance;
        }
        return _instance;
    }

    // Fields
    private List<int> ingredients;

    public bool getIngredient(Collectible collectible)
    {
        if (ingredients[(int)collectible] > 0)
        {
            ingredients[(int)collectible]--;
            return true;
        }
        return false;
    }

    public void addIngredient(Collectible collectible)
    {
        if (ingredients[(int)collectible] < 99) ingredients[(int)collectible]++;
        Debug.Log(World.instance().goal.goalType + " " + World.instance().goal.collectible);
        if (World.instance().goal.goalType == GoalType.Collect && World.instance().goal.collectible == collectible) World.instance().goal.goalComplete();
    }

    public int getNumIngredient(Collectible collectible)
    {
        return ingredients[(int)collectible];
    }
}
