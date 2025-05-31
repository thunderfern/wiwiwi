using UnityEngine;

public class InteractMain : MonoBehaviour {

    public LayerMask mainCharacterLayer;
    public GameObject obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    // for physics
    void FixedUpdate()
    {
        if (Physics2D.BoxCast(obj.transform.position, Vector2.left, new Vector2(2f, 2f), , mainCharacterLayer)) 
        {
            Debug.Log("ayy");
        }
    }
}
