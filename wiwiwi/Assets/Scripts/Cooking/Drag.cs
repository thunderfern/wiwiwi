using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool touchingPot;
    public bool holding;
    private Camera cam;
    private Vector2 pos;

    [SerializeField] public string IDName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        holding = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
            Debug.Log(this.gameObject.name);
        }
    }
    void OnMouseDown()
    {
        if (holding)
        {
            if (touchingPot)
            {
                Debug.Log(this.gameObject.name);
            }
            holding = false;
            Destroy(this.gameObject);
        }
        else
        {
            holding = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Pot")
        {
            touchingPot = true;
        }

    }
    
    public string IngredientName()
    {
        return IDName;
    }
}
