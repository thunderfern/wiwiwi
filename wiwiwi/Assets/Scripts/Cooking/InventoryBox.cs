using UnityEngine;

public class InventoryBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite[] IngredientImageList;
    public string[] IngredientNames;

    public GameObject pot;
    public int slotNumber;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeIngredient(string ingName)
    {
        for (int i = 0; i < IngredientNames.Length; i++)
        {
            if (IngredientNames[i] == ingName)
            {
                GetComponent<SpriteRenderer>().sprite = IngredientImageList[i];
                break;
            }
        }

        if (ingName == "")
        {
            GetComponent<SpriteRenderer>().sprite = IngredientImageList[IngredientImageList.Length - 1];
        }
    }

    void OnMouseDown()
    {
        pot.GetComponent<Pot>().deleteIngredient(slotNumber);
    }
}
