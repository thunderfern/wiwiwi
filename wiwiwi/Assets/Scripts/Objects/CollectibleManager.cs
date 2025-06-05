using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    private static CollectibleManager _instance;

    public static CollectibleManager instance()
    {
        return _instance;
    }

    List<bool> isWaiting;
    List<float> timeTracking;

    void Awake()
    {
        _instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isWaiting = new List<bool>();
        timeTracking = new List<float>();
        for (int i = 0; i < transform.childCount; i++)
        {
            isWaiting.Add(false);
            timeTracking.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (isWaiting[i])
            {
                timeTracking[i] += Time.deltaTime;
                if (timeTracking[i] > 10)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                    isWaiting[i] = false;
                }
            }
        }
    }

    public void reset(int idx)
    {
        isWaiting[idx] = true;
        timeTracking[idx] = 0;
    }
}
