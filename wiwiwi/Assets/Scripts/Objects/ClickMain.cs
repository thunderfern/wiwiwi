using UnityEngine;

public class ClickMain {

    public GameObject obj;

    public ClickMain(GameObject obj)
    {
        this.obj = obj;
    }

    public bool hover()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position);
        if (hit2D && hit2D.transform.gameObject == this.obj) return true;
        return false;
    }
}
