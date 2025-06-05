using UnityEngine;

public class FarmSeedPicker : MonoBehaviour
{
    public GameObject collectible;
    public GameObject water;
    public InteractMain interaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.allowInteraction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                water.SetActive(true);
                SetActive(false);
            }
        }
    }

}
