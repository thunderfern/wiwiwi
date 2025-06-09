using UnityEngine;

public class FarmTransSlot : MonoBehaviour
{

    private InteractMain interaction;
    public GameObject seedMenu;
    public GameObject alertInteraction;

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
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                seedMenu.SetActive(!seedMenu.activeInHierarchy);
            }
        }
        else
        {
            alertInteraction.SetActive(false);
            seedMenu.SetActive(false);
        }
    }
}
