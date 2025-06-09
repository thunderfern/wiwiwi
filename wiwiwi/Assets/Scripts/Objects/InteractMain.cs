using UnityEngine;

public class InteractMain : MonoBehaviour
{

    public LayerMask layermask;
    public LayerMask objlayermask;
    public GameObject obj;
    public GameObject colObj;
    public bool interactable;
    public float dist;
    private bool colliding;

    public InteractMain(GameObject obj, LayerMask layermask)
    {
        this.layermask = layermask;
        this.obj = obj;
        colliding = false;
    }

    public bool allowInteraction()
    {
        if (!interactable)
        {
            obj.layer = LayerMask.NameToLayer("Default");
            return false;
        }
        else obj.layer = (int)Mathf.Log(objlayermask.value, 2);
        if (World.instance().curstate != GameState.Platformer && World.instance().curstate != GameState.Boating) return false;
        RaycastHit2D leftray = Physics2D.Raycast(obj.GetComponent<Collider2D>().bounds.center, Vector2.left, 2f + dist, layermask);
        RaycastHit2D rightray = Physics2D.Raycast(obj.GetComponent<Collider2D>().bounds.center, Vector2.right, 2f + dist, layermask);
        if (leftray && leftray.collider.gameObject == colObj)
        {
            if (objlayermask == (1 << LayerMask.NameToLayer("InteractableE")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj)
                {
                    return true;
                }
            }
            else if (objlayermask == (1 << LayerMask.NameToLayer("InteractableB")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
            }
            else return true;
        }
        if (rightray && rightray.collider.gameObject == colObj)
        {
            if (objlayermask == (1 << LayerMask.NameToLayer("InteractableE")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj) return true;
            }
            else if (objlayermask == (1 << LayerMask.NameToLayer("InteractableB")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
            }
            else return true;
        }
        if (colliding)
        {
            if (objlayermask == (1 << LayerMask.NameToLayer("InteractableE")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj) return true;
            }

            if (objlayermask == (1 << LayerMask.NameToLayer("InteractableB")))
            {
                if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
            }
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == colObj)
        {
            Debug.Log(obj + "enter");
            colliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == colObj)
        {
            Debug.Log(obj + "exit");
            colliding = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject == colObj) {
            colliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject == colObj) {
            colliding = false;
        }
    }
    
}
