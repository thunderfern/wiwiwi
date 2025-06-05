using UnityEngine;

public class InteractMain : MonoBehaviour
{

    public LayerMask mainCharacterLayer;
    public GameObject obj;
    public GameObject colObj;
    public bool interactable;
    private bool colliding;

    public InteractMain(GameObject obj, LayerMask layermask)
    {
        this.mainCharacterLayer = layermask;
        this.obj = obj;
    }

    public bool allowInteraction()
    {
        if (!interactable) return false;
        if (Physics2D.Raycast(obj.transform.position, Vector2.left, 2f, mainCharacterLayer) || Physics2D.Raycast(obj.transform.position, -Vector2.left, 2f, mainCharacterLayer) || colliding)
        {
            Debug.Log("Mmmmmmhm");
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == colObj) colliding = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject == colObj) colliding = false;
    }
    
}
