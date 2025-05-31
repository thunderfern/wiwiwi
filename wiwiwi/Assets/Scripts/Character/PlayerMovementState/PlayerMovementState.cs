using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementState {

    private float xchange;
    private float playerSpeed;

    public PlayerMovementState()
    {
        playerSpeed = 4f;
        xchange = 0f;
    }

    public PlayerMovementState update(GameObject playerObj, PlayerMain player) {
        if (Input.GetKey(KeyCode.D)) xchange = playerSpeed;
        else if (Input.GetKey(KeyCode.A)) xchange = -playerSpeed;
        else if (xchange > 0.01f) xchange = Math.Max(0f, xchange - playerSpeed * 2 * Time.deltaTime);
        else if (xchange < -0.01f) xchange = Math.Min(0f, xchange + playerSpeed * 2 * Time.deltaTime);
        else xchange = 0;

        playerObj.transform.position = playerObj.transform.position + new Vector3(xchange * Time.deltaTime, 0, 0);

        return stateUpdate(playerObj, player);
    }

    public virtual PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player) {
        return this;
    }
}

public class Jump : PlayerMovementState {

    bool jumped;

    public Jump() {
        jumped = false;
    }

    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player) {

        // update character
        if (!jumped) {
            playerObj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            jumped = true;
        }
        else if (playerObj.GetComponent<Rigidbody2D>().linearVelocity.y < 0) return new Fall();

        return this;
    }

}

public class Fall : PlayerMovementState {
    
    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player) {

        // update character
    
        if (player.isGrounded) return new Idle();
    
        return this;
    }
}

public class Idle : PlayerMovementState {

    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player) {
        Animator anim = playerObj.GetComponent<Animator>();

        if (Input.GetKey(KeyCode.W)) return new Jump();
        anim.Play("Player Run");

        return this;
    }
}
