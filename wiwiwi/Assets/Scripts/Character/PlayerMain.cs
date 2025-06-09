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
    public Vector3 cameraOffset;

    public bool isGrounded;

    void updateGroundState() {
        if (Physics2D.Raycast(groundTransform.position, -Vector2.up, 0.2f, groundLayer)) isGrounded = true;
        else isGrounded = false;
    }

    void Start()
    {
        movementState = new Idle();
        isGrounded = true;
        cameraOffset = Camera.main.transform.position - obj.transform.position;
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(Mathf.Min(Mathf.Max(-34.7f, obj.transform.position.x + cameraOffset.x), 115.5f), Mathf.Max(cameraOffset.y + obj.transform.position.y, -21.93f), cameraOffset.z + obj.transform.position.z);
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
        RaycastHit2D leftray = Physics2D.Raycast(obj.transform.position, Vector2.left, 15f, 1 << LayerMask.NameToLayer("InteractableE"));
        RaycastHit2D rightray = Physics2D.Raycast(obj.transform.position, Vector2.right, 15f, 1 << LayerMask.NameToLayer("InteractableE"));
        if (leftray && !rightray) interactableE = leftray.collider.gameObject;
        else if (!leftray && rightray) interactableE = rightray.collider.gameObject;
        else if (rightray && leftray)
        {
            if (leftray.distance < rightray.distance) interactableE = leftray.collider.gameObject;
            else interactableE = rightray.collider.gameObject;
        }
        else interactableE = null;

        // interactable b
        leftray = Physics2D.Raycast(obj.transform.position, Vector2.left, 15f, 1 << LayerMask.NameToLayer("InteractableB"));
        rightray = Physics2D.Raycast(obj.transform.position, Vector2.right, 15f, 1 << LayerMask.NameToLayer("InteractableB"));
        if (leftray && !rightray)
        {
            interactableB = leftray.collider.gameObject;
        }
        else if (!leftray && rightray)
        {
            interactableB = rightray.collider.gameObject;
        }
        else if (rightray && leftray)
        {
            if (leftray.distance < rightray.distance)
            {
                interactableB = leftray.collider.gameObject;
            }
            else
            {
                interactableB = rightray.collider.gameObject;
            }
        }
        else
        {
            interactableB = null;
        }
    }
}

