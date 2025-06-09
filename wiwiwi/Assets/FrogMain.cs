using UnityEngine;

public class FrogMain : MonoBehaviour
{

    private InteractMain interaction;
    public GameObject alertInteraction;
    public BackgroundModes backgroundMode;

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
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                BackgroundEffectsMain.curBackgroundMode = backgroundMode;
            }
        }
        else alertInteraction.SetActive(false);
    }
}
