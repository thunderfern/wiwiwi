using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //0 is close, 1 is open
    public Sprite[] doorState = new Sprite[2];
    bool open = false;
    public GameObject g;


    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = doorState[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == g)
        {
            GetComponent<SpriteRenderer>().sprite = doorState[1];

        }

    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == g)
        {
            GetComponent<SpriteRenderer>().sprite = doorState[0];
        }
    }
    
        
    


}
