using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject vegetable;
    public GameObject cookMain;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() {
        if (cookMain.GetComponent<CookingMain>().cooking)
        {
            GameObject g = GameObject.Instantiate(vegetable);
        }
    }
    
}
