using UnityEngine;

public class InteractMain : MonoBehaviour {

    public LayerMask mainCharacterLayer;
    public GameObject obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(obj.transform.position, Vector2.left, 2.0f, mainCharacterLayer) || Physics2D.Raycast(obj.transform.position, Vector2.right, 2.0f, mainCharacterLayer)) 
        {
            Debug.Log("ayy");
        }
    }
}
