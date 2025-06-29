using UnityEngine;

public class FishingCollectible : MonoBehaviour
{
    public GameObject objDisplay;
    private InteractMain interaction;
    private float elapsedTime;
    private Collectible nextCollectible;
    public Sprite codSprite;
    public Sprite clamSprite;
    public GameObject playerObj;
    public GameObject obj;
    public GameObject alterInteraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedTime = 0;
        nextCollectible = Collectible.Cod;
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        alterInteraction.SetActive(false);

        if (World.instance().curstate == GameState.Fishing)
        {
            elapsedTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                elapsedTime = 0;
                World.instance().curstate = GameState.Platformer;
                return;
            }
            if (elapsedTime > 2.5f)
            {
                elapsedTime = 0;
                if (nextCollectible == Collectible.Cod)
                {
                    objDisplay.GetComponent<SpriteRenderer>().sprite = codSprite;
                }
                else
                {
                    objDisplay.GetComponent<SpriteRenderer>().sprite = clamSprite;
                }
                objDisplay.SetActive(true);
                World.instance().curstate = World.instance().prevstate[0];
                World.instance().prevstate.RemoveAt(0);
                Inventory.instance().addIngredient(nextCollectible);
                if (Random.Range(0, 2) == 0)
                {
                    nextCollectible = Collectible.Cod;
                }
                else
                {
                    nextCollectible = Collectible.Clam;
                }

            }
        }
        else if (interaction.allowInteraction())
        {
            alterInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance().PlaySound(AudioType.Splash);
                World.instance().prevstate.Insert(0, World.instance().curstate);
                World.instance().curstate = GameState.Fishing;
                Animator anim = playerObj.GetComponent<Animator>();
                anim.SetInteger("playerMovement", 4);
            }
        }
    }
}
