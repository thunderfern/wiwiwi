using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    private PlayerMovementState movementState;
    public GameObject obj;

    void Start() {
        movementState = new Idle();
    }

    // Update is called once per frame
    void Update() {
        movementState = movementState.update(obj);
    }
}

