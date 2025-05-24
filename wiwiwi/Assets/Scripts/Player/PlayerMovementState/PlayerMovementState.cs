using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementState
{
    private float xchange;

    public PlayerMovementState()
    {
        xchange = 0f;
    }

    public PlayerMovementState update(GameObject obj)
    {
        if (Input.GetKey(KeyCode.D)) xchange = 1.0f;
        else if (Input.GetKey(KeyCode.A)) xchange = -1.0f;
        else if (xchange > 0.01f) xchange = Math.Max(0f, xchange - 1.0f * Time.deltaTime);
        else if (xchange < -0.01f) xchange = Math.Min(0f, xchange + 1.0f * Time.deltaTime);
        else xchange = 0;

        obj.transform.position = obj.transform.position + new Vector3(xchange * Time.deltaTime, 0, 0);

        return stateUpdate(obj);
    }

    public virtual PlayerMovementState stateUpdate(GameObject obj) {
        return this;
    }
}

public class Jump : PlayerMovementState {
    bool jumped;

    public Jump() {
        jumped = false;
    }

    public override PlayerMovementState stateUpdate(GameObject obj) {

        // update character
        if (!jumped) {
            obj.transform.position = obj.transform.position + new Vector3(0, 10f, 0);
            jumped = true;
        }

        return this;
    }

}

public class Idle : PlayerMovementState
{
    public override PlayerMovementState stateUpdate(GameObject obj)
    {
        if (Input.GetKey(KeyCode.W)) return new Jump();
        return this;
    }
}
