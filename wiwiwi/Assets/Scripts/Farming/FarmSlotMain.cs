using UnityEngine;


public class FarmSlotMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int inactiveMembers = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).activeInHierarchy) inactiveMembers++;
        }
        if (inactiveMembers == 3) transform.GetChild(0).gameObject.SetActive(true);
    }
}
