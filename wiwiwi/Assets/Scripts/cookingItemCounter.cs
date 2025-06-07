using UnityEngine;
using TMPro;
using System;

public class cookingItemCounter : MonoBehaviour
{
    public GameObject textObj;
    public Collectible collectible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textObj.GetComponent<TMP_Text>().text = Convert.ToString(Inventory.instance().getNumIngredient(collectible));
    }
}
