using UnityEngine;

public class FishingMain : MonoBehaviour
{

    private float passedTime;
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime > 2)
        {
            passedTime = 0;
            obj.SetActive(false);
        }
    }
}
