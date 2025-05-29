using UnityEngine;

public class DragandDrog : MonoBehaviour
{
    private bool holding = false;
    private Camera cam;
    private Vector2 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding){
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
            Debug.Log(this.gameObject.name);
        }
    }
    void OnMouseDown(){
        holding = true;
    }

    void OnMouseUp(){
        holding = false;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("uhhh");
    }

    void OnTriggerStay2D(Collider2D other){
        Debug.Log("poo");
        if (other.gameObject.name == "Pot"){
            Debug.Log("WEED");
        }
    }
}
