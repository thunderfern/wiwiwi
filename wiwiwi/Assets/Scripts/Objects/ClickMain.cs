using UnityEngine;

public class ClickMain {

    public GameObject obj;

    public ClickMain(GameObject obj)
    {
        this.obj = obj;
    }

    public bool hover()
    {
        //RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit && hit.collider != null)
        {
            if (hit.collider.gameObject == this.obj) return true;
        }
        return false;
    }
}
