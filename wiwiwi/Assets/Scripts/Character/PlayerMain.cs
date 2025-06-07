using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {
    // Start is called before the first frame update
    private PlayerMovementState movementState;
    public GameObject obj;
    public Transform groundTransform;
    public LayerMask groundLayer;
    public GameObject interactableE;
    public GameObject interactableB;

    public bool isGrounded;

    void updateGroundState() {
        if (Physics2D.Raycast(groundTransform.position, -Vector2.up, 0.2f, groundLayer)) isGrounded = true;
        else isGrounded = false;
    }

    void Start()
    {
        movementState = new Idle();
        isGrounded = true;
    }

    void Update()
    {
        
    }

    // For physics updates
    void FixedUpdate()
    {
        if (World.instance().curstate == GameState.Platformer)
        {
            updateGroundState();
            movementState = movementState.update(obj, this);
        }

        // interactable e
        RaycastHit2D leftray = Physics2D.Raycast(obj.transform.position, Vector2.left, 10f, LayerMask.NameToLayer("InteractableE"));
        RaycastHit2D rightray = Physics2D.Raycast(obj.transform.position, Vector2.right, 10f, LayerMask.NameToLayer("InteractableE"));
        if (leftray && !rightray) interactableE = leftray.collider.gameObject;
        if (!leftray && rightray) interactableE = rightray.collider.gameObject;
        if (rightray && leftray)
        {
            if (leftray.distance < rightray.distance) interactableE = leftray.collider.gameObject;
            else interactableE = rightray.collider.gameObject;
        }
        
        // interactable b
        leftray = Physics2D.Raycast(obj.transform.position, Vector2.left, 10f, LayerMask.NameToLayer("InteractableB"));
        rightray = Physics2D.Raycast(obj.transform.position, Vector2.right, 10f, LayerMask.NameToLayer("InteractableB"));
        if (leftray && !rightray) interactableB = leftray.collider.gameObject;
        if (!leftray && rightray) interactableB = rightray.collider.gameObject;
        if (rightray && leftray) {
            if (leftray.distance < rightray.distance) interactableB = leftray.collider.gameObject;
            else interactableB = rightray.collider.gameObject;
        }
    }
}

