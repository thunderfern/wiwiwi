using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private string[,] soup = new { };
    public string[] ingredients = new string[3];
    public GameObject[] InventoryBoxes;
    public string ingredientName = "";
    public bool click;

    public string[] soupNames = new string[]{"Tomato Soup", "Mushroom Soup", "Fish Soup", "Carrot Soup", "Clam Chowder", "Nothing", "Suspicious Looking Soup"};
    public Sprite[] soupImageList;

    public string soup;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        updateInventoryBoxes();
        soupDisplay();

    }

    private void Add()
    {

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name != null)
        {
            ingredientName = other.GetComponent<Drag>().IngredientName();
            Debug.Log(ingredientName);
            if (Input.GetMouseButtonDown(0))
            {
                tryAdd(ingredientName);
                Destroy(other.gameObject);




            }


        }
    }

    void tryAdd(string ingredient)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == "")
            {
                ingredients[i] = ingredient;
                Debug.Log(ingredients[0] + ingredients[1] + ingredients[2]);
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
            return "Tomato Soup";
        }
        else if (mushroomCount == 1 && onionCount == 1 && tomatoCount == 0 && basilCount == 0 && codCount == 0 && carrotCount == 0 && potatoCount == 0 & clamCount == 0)
        {
            return "Mushroom Soup";
        }
        else if (codCount == 1 && tomatoCount == 1 && basilCount == 1)
        {
            return "Fish Soup";

        }
        else if (carrotCount == 1 && tomatoCount == 1 && onionCount == 1)
        {
            return "Carrot Soup";
        }
        else if (potatoCount == 1 && clamCount == 1 && basilCount == 1)
        {
            return "Clam Chowder";
        }
        else if (hasIngredients)
        {
            return "Suspicious Looking Soup";
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
                Debug.Log(soupName);
                break;
            }
        }

    }
}
