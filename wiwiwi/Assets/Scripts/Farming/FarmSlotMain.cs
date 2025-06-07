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
        for (int i = 1; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy) inactiveMembers++;
            else
            {
                for (int j = 1; j < i; j++)
                {
                    transform.GetChild(j).gameObject.SetActive(false);
                }
                if (i != 1) transform.GetChild(0).GetComponent<InteractMain>().interactable = false;
            }
        }
        if (inactiveMembers == 3) transform.GetChild(0).GetComponent<InteractMain>().interactable = true;
    }
}
