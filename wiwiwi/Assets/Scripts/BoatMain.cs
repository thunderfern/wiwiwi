using UnityEngine;

public class BoatMain : MonoBehaviour
{

    private InteractMain interaction;
    private InteractMain leftinteraction;
    private InteractMain rightinteraction;
    private float boatSpeed;
    public GameObject obj;
    public GameObject playerObj;
    public GameObject pond;
    public GameObject leftcol;
    public GameObject rightcol;
    private GameObject boatBack;
    public GameObject invIcon;
    public GameObject recipeIcon;
    private float xchange;
    private Vector3 mcoffset;
    private Vector3 boatBackOffset;
    public Sprite sailOut;
    public Sprite sailIn;
    private Vector3 leftPlayerPos;
    private Vector3 rightPlayerPos;
    public GameObject alertInteraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftPlayerPos = new Vector3(23.64f, -0.35f, 0f);
        rightPlayerPos = new Vector3(89.98f, -0.83f, 0f);
        boatBack = obj.transform.GetChild(0).gameObject;
        interaction = GetComponent<InteractMain>();
        leftinteraction = leftcol.GetComponent<InteractMain>();
        rightinteraction = rightcol.GetComponent<InteractMain>();
        xchange = 0;
        mcoffset = new Vector3(39.78f - obj.transform.position.x, -0.82f - obj.transform.position.y, 0);
        boatBackOffset = new Vector3(boatBack.transform.position.x - obj.transform.position.x, boatBack.transform.position.y - obj.transform.position.y, 0);
        boatSpeed = 3f;
        obj.SetActive(false);

        /*Debug.Log(37.02f - obj.transform.position.x - pond.transform.position.x);
        Debug.Log(obj.transform.position.x);
        Debug.Log(pond.transform.position.x);*/
    }

    // Update is called once per frame
    void Update()
    {
        alertInteraction.SetActive(false);
        if (playerObj.transform.position.x < obj.transform.position.x)
        {
            alertInteraction.transform.position = new Vector3(-4.89f + obj.transform.position.x, -4.72f + obj.transform.position.y, 0);
        }
        else
        {
            alertInteraction.transform.position = new Vector3(4.89f + obj.transform.position.x, -4.72f + obj.transform.position.y, 0);
        }
        if (World.instance().curstate == GameState.Boating)
        {
            invIcon.SetActive(false);
            recipeIcon.SetActive(false);
            Camera.main.orthographicSize = 10f;
            if (Input.GetKey(KeyCode.D)) xchange = boatSpeed;
            else if (Input.GetKey(KeyCode.A)) xchange = -boatSpeed;
            else if (xchange > 0.01f)
            {
                xchange = Mathf.Max(0f, xchange - boatSpeed * 2 * Time.deltaTime);
            }
            else if (xchange < -0.01f)
            {
                xchange = Mathf.Min(0f, xchange + boatSpeed * 2 * Time.deltaTime);
            }
            else xchange = 0;

            if (rightinteraction.allowInteraction())
            {
                alertInteraction.SetActive(true);
                if (xchange > 0) xchange = 0;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    playerObj.transform.position = new Vector3(rightPlayerPos.x, rightPlayerPos.y, playerObj.transform.position.z);
                    Camera.main.orthographicSize = 5f;
                    World.instance().curstate = GameState.Platformer;
                    return;
                }
            }

            if (leftinteraction.allowInteraction())
            {
                alertInteraction.SetActive(true);
                if (xchange < 0) xchange = 0;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    playerObj.transform.position = new Vector3(leftPlayerPos.x, leftPlayerPos.y, playerObj.transform.position.z);
                    Camera.main.orthographicSize = 5f;
                    World.instance().curstate = GameState.Platformer;
                    invIcon.SetActive(true);
                    recipeIcon.SetActive(true);
                    return;
                }
            }

            if (xchange < 0)
            {
                obj.GetComponent<SpriteRenderer>().flipX = false;
                obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerObj.GetComponent<SpriteRenderer>().flipX = false;
                if (mcoffset.x < 0)
                {
                    boatBackOffset = new Vector3(boatBackOffset.x * -1, boatBackOffset.y, boatBackOffset.z);
                    mcoffset = new Vector3(mcoffset.x * -1, mcoffset.y, mcoffset.z);
                }
            }
            else if (xchange > 0)
            {
                obj.GetComponent<SpriteRenderer>().flipX = true;
                obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
                playerObj.GetComponent<SpriteRenderer>().flipX = true;
                if (mcoffset.x > 0)
                {
                    boatBackOffset = new Vector3(boatBackOffset.x * -1, boatBackOffset.y, boatBackOffset.z);
                    mcoffset = new Vector3(mcoffset.x * -1, mcoffset.y, mcoffset.z);
                }
            }

            obj.transform.position = obj.transform.position + new Vector3(xchange * Time.deltaTime, 0, 0);
            boatBack.transform.position = new Vector3(obj.transform.position.x + boatBackOffset.x, obj.transform.position.y + boatBackOffset.y, boatBack.transform.position.z);
            playerObj.transform.position = new Vector3(obj.transform.position.x + mcoffset.x, obj.transform.position.y + mcoffset.y, playerObj.transform.position.z);
        }
        else if (interaction.allowInteraction())
        {
            alertInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.B))
            {
                World.instance().curstate = GameState.Boating;
                playerObj.transform.position = new Vector3(obj.transform.position.x + mcoffset.x, obj.transform.position.y + mcoffset.y, playerObj.transform.position.z);
            }
        }

        if (xchange != 0 || World.instance().curstate != GameState.Boating)
        {
            obj.GetComponent<SpriteRenderer>().sprite = sailOut;
        }
        else {
            obj.GetComponent<SpriteRenderer>().sprite = sailIn;
        }
    }

}
