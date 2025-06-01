using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private string[,] soup = new { };
    public string[] ingredients = new string[3];
    public string ingredientName = "";
    public bool click;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
}
