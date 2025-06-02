using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    public GameObject obj;
    private Vector3 originalPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = obj.transform.position - new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position = originalPos + new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }
}
