using UnityEngine;

public class BackgroundEffectsMain : MonoBehaviour {
    int raining;
    public GameObject burrow;
    private bool inBurrow;
    private InteractMain burrowInteract;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raining = 0;
        inBurrow = false;
        burrowInteract = burrow.GetComponent<InteractMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (burrowInteract.allowInteraction())
        {
            if (inBurrow)
            {
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
                AudioManager.instance().BackgroundVolume(Mathf.Max(1.0f - timer / 5.0f, 0f));
                if (timer > 5)
                {
                    inBurrow = true;
                    timer = 0f;
                }
            }
        }
        else
        {
            if (inBurrow)
            {
                timer += Time.deltaTime;
                AudioManager.instance().BackgroundVolume(Mathf.Max(1.0f - timer / 5.0f, 0f));
                if (timer > 5)
                {
                    inBurrow = false;
                    timer = 0f;
                }
            }
                else
                {
                    timer = 0f;
                }
        }
        if (inBurrow)
        {
            AudioManager.instance().PlayBackground(BackgroundMusic.BurrowBackground);
        }
        else
        {
            if (raining == 0) AudioManager.instance().PlayBackground(BackgroundMusic.OverworldBackground);
            else if (raining == 1) AudioManager.instance().PlayBackground(BackgroundMusic.RainBackground);
            else if (raining == 2) AudioManager.instance().PlayBackground(BackgroundMusic.ThunderBackground);
        }
    }
}
