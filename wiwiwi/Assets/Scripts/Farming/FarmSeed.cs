using UnityEngine;

public class FarmSeed : MonoBehaviour
{

    public GameObject collectible;
    public GameObject farmWater;
    public GameObject obj;
    private InteractMain interaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction = GetComponent<InteractMain>();
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, obj.transform.position.z);

        if (!Input.GetMouseButton(0))
        {
            if (interaction.allowInteraction())
            {
                farmWater.SetActive(true);
            }
            obj.SetActive(false);
        }
    }
}
