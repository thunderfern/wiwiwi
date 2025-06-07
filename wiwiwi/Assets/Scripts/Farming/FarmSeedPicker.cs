using UnityEngine;

public class FarmSeedPicker : MonoBehaviour
{
    public GameObject collectObj;
    public GameObject farmSeed;
    public ClickMain clicker;
    public GameObject obj;
    public Collectible seedType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clicker = new ClickMain(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicker.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                farmSeed.SetActive(true);
                collectObj.GetComponent<FarmCollect>().collectible = this.seedType;
            }   
        }
    }

}
