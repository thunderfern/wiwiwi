using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 cameraOrig;
    private Vector3 objOrig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOrig = Camera.main.transform.position;
        objOrig = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objOrig.x + (Camera.main.transform.position.x - cameraOrig.x) * 0.25f, objOrig.y + (Camera.main.transform.position.y - cameraOrig.y) * 0.25f, objOrig.z);
    }
}
