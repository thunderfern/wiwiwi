using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryMain : MonoBehaviour
{
    public GameObject obj;
    public GameObject closeObj;
    private ClickMain closeObjClick;

    public List<Sprite> objectSprites;
    public GameObject sampleEntry;
    public GameObject sampleEntrySprite;

    public List<GameObject> entries;
    public List<ClickMain> entryClickers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeObjClick = new ClickMain(closeObj);

        entries = new List<GameObject>();
        entryClickers = new List<ClickMain>();

        for (int i = 0; i < 8; i++)
        {
            GameObject tmp = Instantiate(sampleEntry);
            tmp.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[i];
            tmp.transform.position = new Vector3(sampleEntry.transform.position.x + 1.3f * (i % 3), sampleEntry.transform.position.y - 1.3f * (i / 3), sampleEntry.transform.position.z);
            entries.Add(tmp);
        }
        for (int i = 0; i < 8; i++)
        {
            ClickMain tmpClick = new ClickMain(entries[i]);
            entryClickers.Add(tmpClick);
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
        getItem();


    }

    public Tuple<Collectible, GameObject> getItem()
    {
        Tuple<Collectible, GameObject> tmpans;
        if (Input.GetMouseButtonDown(0)) {
            for (int i = 0; i < 8; i++)
            {
                if (entryClickers[i].hover())
                {
                    GameObject entrySpriteAns = Instantiate(sampleEntrySprite);
                    entrySpriteAns.GetComponent<SpriteRenderer>().sprite = objectSprites[i];
                    tmpans = new Tuple<Collectible, GameObject>((Collectible)(i), entrySpriteAns);
                    return tmpans;
                }
            }
        }
        return null;
    }
}
