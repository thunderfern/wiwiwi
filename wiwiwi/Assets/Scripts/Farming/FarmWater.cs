using UnityEngine;

public class FarmWater : MonoBehaviour
{

    public GameObject collectible;
    public GameObject obj;
    private InteractMain interaction;
    //public ClickMain clicker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //clicker = new ClickMain(obj);
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collectible.SetActive(true);
                obj.SetActive(false);
            }
        }
        /*if (clicker.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                collectible.SetActive(true);
                obj.SetActive(false);
            }
        }*/
    }
}
