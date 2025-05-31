using UnityEngine;

public class Pot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private string[,] soup = new { };
    //private string[,] ingredients = { };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Add()
    {

    }

    void OnMouseDown()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != null)
        {
            Debug.Log(other.GetComponent<Drag>().Name());
        }
    }
}
