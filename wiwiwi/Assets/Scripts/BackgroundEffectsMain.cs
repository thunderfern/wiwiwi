using UnityEngine;

public class BackgroundEffectsMain : MonoBehaviour {
    int raining;
    public GameObject burrow;
    public GameObject rainObj;
    public static bool inBurrow;
    private InteractMain burrowInteract;
    private float timer;
    private float rainTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raining = 0;
        inBurrow = false;
        burrowInteract = burrow.GetComponent<InteractMain>();
        rainTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rainTimer += Time.deltaTime;
        if (burrowInteract.allowInteraction())
        {
            if (inBurrow)
            {
                timer = 0f;
                AudioManager.instance().BackgroundVolume(Mathf.Max(0.25f));
            }
            else
            {
                timer += Time.deltaTime;
                AudioManager.instance().BackgroundVolume(Mathf.Max(0f));
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
                AudioManager.instance().BackgroundVolume(Mathf.Max(0f));
                if (timer > 5)
                {
                    inBurrow = false;
                    timer = 0f;
                }
            }
            else
            {
                AudioManager.instance().BackgroundVolume(Mathf.Max(0.25f));
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

        if (!inBurrow)
        {
            if (raining == 0 && rainTimer > 10)
            {
                raining++;
                rainTimer = 0;
                AudioManager.instance().PlaySound(AudioType.Rain, 0.05f);
            }
            else if (raining == 1 && rainTimer > 5)
            {
                raining++;
                rainTimer = 0;
                AudioManager.instance().StopSound(AudioType.Rain);
                AudioManager.instance().PlaySound(AudioType.RainThunder);
            }
            else if (raining == 2 && rainTimer > 5)
            {
                raining = 0;
                rainTimer = 0;
                AudioManager.instance().StopSound(AudioType.RainThunder);
            }
        }

        if (raining != 0)
            {
                rainObj.SetActive(true);
            }
            else
            {
                rainObj.SetActive(false);
            }
    }
}
