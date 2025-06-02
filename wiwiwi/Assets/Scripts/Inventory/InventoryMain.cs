using System.Collections.Generic;
using UnityEngine;

public class InventoryMain : MonoBehaviour
{
    public GameObject obj;
    public GameObject closeObj;
    private ClickMain closeObjClick;

    public List<Sprite> objectSprites;
    public GameObject sampleEntry;

    public List<GameObject> entries;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeObjClick = new ClickMain(closeObj);

        entries.Add(sampleEntry);
        for (int i = 1; i < 8; i++)
        {
            GameObject tmp = Instantiate(sampleEntry, sampleEntry.transform.parent);
            tmp.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[i];
            tmp.transform.position = new Vector3(sampleEntry.transform.position.x + 1.3f * (i % 3), sampleEntry.transform.position.y - 1.3f * (i / 3), sampleEntry.transform.position.z);
            entries.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().curstate != GameState.Inventory)
        {
            obj.SetActive(false);
        }
        if (closeObjClick.hover())
        {
            if (Input.GetMouseButtonDown(0))
            {
                World.instance().curstate = World.instance().prevstate;
            }
        }

        
    }
}
