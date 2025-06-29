using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementState {

    public float xchange;
    private float playerSpeed;

    public PlayerMovementState()
    {
        playerSpeed = 4f;
        xchange = 0f;
    }
    
    public virtual void debugState()
    {
        
    }

    public PlayerMovementState update(GameObject playerObj, PlayerMain player)
    {
        if (Input.GetKey(KeyCode.D)) xchange = playerSpeed;
        else if (Input.GetKey(KeyCode.A)) xchange = -playerSpeed;
        else if (xchange > 0.01f) xchange = Math.Max(0f, xchange - playerSpeed * 2 * Time.deltaTime);
        else if (xchange < -0.01f) xchange = Math.Min(0f, xchange + playerSpeed * 2 * Time.deltaTime);
        else xchange = 0;

        if (xchange < 0)
        {
            playerObj.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (xchange > 0)
        {
            playerObj.GetComponent<SpriteRenderer>().flipX = true;
        }

        playerObj.transform.position = playerObj.transform.position + new Vector3(xchange * Time.deltaTime, 0, 0);
        //debugState();
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

    public override void debugState()
    {
        Debug.Log("Jump\n");
    }

    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player)
    {
        Animator anim = playerObj.GetComponent<Animator>();
        anim.SetInteger("playerMovement", 2);

        // update character
        if (!jumped)
        {
            playerObj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            jumped = true;
        }
        else if (playerObj.GetComponent<Rigidbody2D>().linearVelocity.y <= 0) return new Fall();

        return this;
    }

}

public class Fall : PlayerMovementState {

    public override void debugState()
    {
        Debug.Log("Fall\n");
    }
    
    
    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player)
    {

        // update character
        Animator anim = playerObj.GetComponent<Animator>();
        anim.SetInteger("playerMovement", 3);

        if (player.isGrounded)
        {
            if (BackgroundEffectsMain.inBurrow)
            {
                AudioManager.instance().PlaySound(AudioType.LandingOnDirt);
            }
            else AudioManager.instance().PlaySound(AudioType.LandingOnGrass);
            return new Idle();
        }

        return this;
    }
}

public class Idle : PlayerMovementState {
    
    public override void debugState()
    {
        Debug.Log("Idle\n");
    }

    public override PlayerMovementState stateUpdate(GameObject playerObj, PlayerMain player)
    {
        Animator anim = playerObj.GetComponent<Animator>();
        if (xchange != 0)
        {
            anim.SetInteger("playerMovement", 1);
            AudioManager.instance().PlaySound(AudioType.Footsteps);

        }
        else anim.SetInteger("playerMovement", 0);

        if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.Space) )
        {
            AudioManager.instance().PlaySound(AudioType.Jumping);
            return new Jump();
        }

        return this;
    }
}
