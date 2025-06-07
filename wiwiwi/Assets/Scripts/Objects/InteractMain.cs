using UnityEngine;

public class InteractMain : MonoBehaviour
{

    public LayerMask layermask;
    public LayerMask objlayermask;
    public GameObject obj;
    public GameObject colObj;
    public bool interactable;
    private bool colliding;

    public InteractMain(GameObject obj, LayerMask layermask)
    {
        this.layermask = layermask;
        this.obj = obj;
        this.colliding = false;
    }

    public bool allowInteraction()
    {
        if (!interactable) {
            obj.layer = LayerMask.NameToLayer("Default");
            return false;
        }
        else obj.layer = (int)Mathf.Log(objlayermask.value, 2);
        if (World.instance().curstate != GameState.Platformer) return false;
        RaycastHit2D leftray = Physics2D.Raycast(obj.transform.position, Vector2.left, 2f, layermask);
        RaycastHit2D rightray = Physics2D.Raycast(obj.transform.position, Vector2.right, 2f, layermask);
        if (leftray && leftray.collider.gameObject == colObj)
        {
            if (objlayermask == LayerMask.NameToLayer("InteractableE"))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj)
                {
                    return true;
                }
            }
                else if (objlayermask == LayerMask.NameToLayer("InteractableB"))
                {
                    if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
                }
                else return true;
        }
        if (rightray && rightray.collider.gameObject == colObj)
        {
            if (objlayermask == LayerMask.NameToLayer("InteractableE"))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj) return true;
            }
            else if (objlayermask == LayerMask.NameToLayer("InteractableB"))
            {
                if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
            }
            else return true;
        }
        if (colliding)
        {
            if (objlayermask == LayerMask.NameToLayer("InteractableE"))
            {
                if (colObj.GetComponent<PlayerMain>().interactableE == obj) return true;
            }
            
            if (objlayermask == LayerMask.NameToLayer("InteractableB"))
            {
                if (colObj.GetComponent<PlayerMain>().interactableB == obj) return true;
            }
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject == colObj) {
            colliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == colObj) {
            colliding = false;
        }
    }
    
}
