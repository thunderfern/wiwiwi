using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 cameraOrig;
    private Vector3 objOrig;
    public float scaleAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOrig = Camera.main.transform.position;
        objOrig = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objOrig.x + (Camera.main.transform.position.x - cameraOrig.x) * scaleAmount, objOrig.y + (Camera.main.transform.position.y - cameraOrig.y) * scaleAmount, objOrig.z);
    }
}
