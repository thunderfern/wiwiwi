using UnityEngine;

public class BackgroundEffectsMain : MonoBehaviour {
    int raining;
    public GameObject burrow;
    public GameObject rainObj;
    private bool inBurrow;
    private InteractMain burrowInteract;
    private float timer;
    private float waitTime;
    private float rainTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitTime = 5.0f;
        raining = 0;
        inBurrow = false;
        burrowInteract = burrow.GetComponent<InteractMain>();
        rainTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rainTimer += Time.deltaTime;
        if (waitTime < 5.0f)
        {
            waitTime += Time.deltaTime;
        }
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
                    waitTime = 0f;
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
                    waitTime = 0f;
                }
            }
            else
            {
                timer = 0f;
            }
        }
        //if (waitTime >= 1.0f)
        //{
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
        //}
        if (raining == 0 && rainTimer > 10)
        {
            raining++;
            rainTimer = 0;
        }
        else if (raining == 1 && rainTimer > 5)
        {
            raining++;
            rainTimer = 0;
        }
        else if (raining == 2 && rainTimer > 5)
        {
            raining = 0;
            rainTimer = 0;
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
