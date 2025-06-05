using UnityEngine;

public class FarmTransSlot : MonoBehaviour
{

    private InteractMain interaction;
    public GameObject seedMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
        seedMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                seedMenu.SetActive(!seedMenu.activeInHierarchy);
            }
        }
    }
}
