using UnityEngine;

public class FarmWater : MonoBehaviour
{

    public GameObject collectible;
    public GameObject obj;
    private InteractMain interaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
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
    }
}
