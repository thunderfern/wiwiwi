using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool isHover = false;

   
    private void OnMouseEnter()
    {
        isHover = true;
    }

    private void OnMouseExit()
    {
        isHover = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHover)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
