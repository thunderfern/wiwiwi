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
    private float xchange;
    private Vector2 mcoffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
        leftinteraction = leftcol.GetComponent<InteractMain>();
        rightinteraction = rightcol.GetComponent<InteractMain>();
        xchange = 0;
        mcoffset = new Vector3(41.57f - obj.transform.position.x - pond.transform.position.x, -1.1f - obj.transform.position.y - pond.transform.position.y, playerObj.transform.position.z);
        boatSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (World.instance().curstate == GameState.Boating) {
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
                if (xchange > 0) xchange = 0;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Camera.main.orthographicSize = 5f;
                    World.instance().curstate = GameState.Platformer;
                }
            }

            if (leftinteraction.allowInteraction())
            {
                Debug.Log("ok bro\n");
                if (xchange < 0) xchange = 0;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Camera.main.orthographicSize = 5f;
                    World.instance().curstate = GameState.Platformer;
                }
            }

            obj.transform.position = obj.transform.position + new Vector3(xchange * Time.deltaTime, 0, 0);
            playerObj.transform.position = new Vector3(xchange * Time.deltaTime + obj.transform.position.x + pond.transform.position.x + mcoffset.x, obj.transform.position.y + pond.transform.position.y + mcoffset.y, 0);
        }
        else if (interaction.allowInteraction())
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                World.instance().curstate = GameState.Boating;
                playerObj.transform.position = new Vector3(obj.transform.position.x + pond.transform.position.x + mcoffset.x, obj.transform.position.y + pond.transform.position.y + mcoffset.y, playerObj.transform.position.z);
            }
        }
    }

}
