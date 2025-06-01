using UnityEngine;

public class InteractMain {

    public LayerMask mainCharacterLayer;
    public GameObject obj;
    public bool interactable;

    public InteractMain(GameObject obj, LayerMask layermask)
    {
        this.mainCharacterLayer = layermask;
        this.obj = obj;
    }

    public bool allowInteraction()
    {
        if (!interactable) return false;
        if (Physics2D.Raycast(obj.transform.position, Vector2.left, 2f, mainCharacterLayer)) return true;
        return false;
    }
}
