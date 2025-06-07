using UnityEngine;
using System.Collections;
using System;

public class Pot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private string[,] soup = new { };
    public string[] ingredients = new string[3];
    public GameObject[] InventoryBoxes;
    public string ingredientName = "";
    public bool click;

    public string[] soupNames = new string[]{"TomatoSoup", "MushroomSoup", "FishSoup", "CarrotSoup", "ClamChowder", "Nothing", "UnknownSoup"};
    public Sprite[] soupImageList;

    public string soup;

    private Collider2D curCollider;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (curCollider != null)
            {
                ingredientName = curCollider.GetComponent<Drag>().IngredientName();
                Debug.Log(ingredientName);
                tryAdd(ingredientName);
                Destroy(curCollider.gameObject);
                curCollider = null;
            }
        }
        updateInventoryBoxes();
        soupDisplay();
    }

    private void Add()
    {

    }

    public void resetPot()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i] = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Drag>())
        {
            curCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (curCollider == other)
        {
            curCollider = null;
        }
    }

    void tryAdd(string ingredient)
    {
        
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == "")
            {
                if (Inventory.instance().getIngredient((Collectible)Enum.Parse(typeof(Collectible), ingredient)))
                {
                    ingredients[i] = ingredient;
                    Debug.Log(ingredients[0] + ingredients[1] + ingredients[2]);
                }
                break;
            }
        }
    }

    void updateInventoryBoxes()
    {
        for (int i = 0; i < InventoryBoxes.Length; i++)
        {
            InventoryBoxes[i].GetComponent<InventoryBox>().ChangeIngredient(ingredients[i]);
        }
    }

    public void deleteIngredient(int Slot)
    {
        ingredients[Slot] = "";
    }

    public string soupSearch()
    {
        int tomatoCount, onionCount, basilCount, mushroomCount, codCount, carrotCount, potatoCount, clamCount;
        tomatoCount = 0;
        onionCount = 0;
        basilCount = 0;
        mushroomCount = 0;
        codCount = 0;
        carrotCount = 0;
        potatoCount = 0;
        clamCount = 0;

        int ingredientCount = 0;

        bool hasIngredients = false;


        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == "Tomato")
            {
                tomatoCount++;
            }
            if (ingredients[i] == "Onion")
            {
                onionCount++;
            }
            if (ingredients[i] == "Basil")
            {
                basilCount++;
            }
            if (ingredients[i] == "Mushroom")
            {
                mushroomCount++;
            }
            if (ingredients[i] == "Cod")
            {
                codCount++;
            }
            if (ingredients[i] == "Carrot")
            {
                carrotCount++;
            }
            if (ingredients[i] == "Potato")
            {
                potatoCount++;
            }
            if (ingredients[i] == "Clam")
            {
                clamCount++;
            }
        }
        
        int[] soup = new int[] { tomatoCount, onionCount, basilCount, mushroomCount, codCount, carrotCount, potatoCount, clamCount };


        for (int i = 0; i < soup.Length; i++)
        {
            if (soup[i] >= 1)
            {
                ingredientCount += soup[i];
            }
        }

        if (ingredientCount > 1)
        {
            hasIngredients = true;
        }


        if (tomatoCount == 1 && onionCount == 1 && basilCount == 1)
        {
            return "TomatoSoup";
        }
        else if (mushroomCount == 1 && onionCount == 1 && tomatoCount == 0 && basilCount == 0 && codCount == 0 && carrotCount == 0 && potatoCount == 0 & clamCount == 0)
        {
            return "MushroomSoup";
        }
        else if (codCount == 1 && tomatoCount == 1 && basilCount == 1)
        {
            return "FishSoup";

        }
        else if (carrotCount == 1 && tomatoCount == 1 && onionCount == 1)
        {
            return "CarrotSoup";
        }
        else if (potatoCount == 1 && clamCount == 1 && basilCount == 1)
        {
            return "ClamChowder";
        }
        else if (hasIngredients)
        {
            return "UnknownSoup";
        }
        else
        {
            return "Nothing";
        }
    }
    public void soupDisplay()
    {
        string soupName = soupSearch();
        for (int i = 0; i < soupNames.Length; i++)
        {
            if (soupNames[i] == soupName)
            {
                GetComponent<SpriteRenderer>().sprite = soupImageList[i];
                break;
            }
        }

    }
}
