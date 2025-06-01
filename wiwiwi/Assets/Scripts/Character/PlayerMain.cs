using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {
    // Start is called before the first frame update
    private PlayerMovementState movementState;
    public GameObject obj;
    public Transform groundTransform;
    public LayerMask groundLayer;

    public bool isGrounded;

    void updateGroundState() {
        if (Physics2D.Raycast(groundTransform.position, -Vector2.up, 0.1f, groundLayer)) isGrounded = true;
        else isGrounded = false;
    }

    void Start() {
        movementState = new Idle();
        isGrounded = true;
    }

    // For physics updates
    void FixedUpdate() {
        if (World.instance().curstate == GameState.Platformer) {
            updateGroundState();
            movementState = movementState.update(obj, this);
        }
    }
}

