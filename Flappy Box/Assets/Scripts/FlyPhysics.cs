using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyPhysics{

    public static Vector3 FlySine(float t) {

        // y = sinx, y' = cosx
        float vy = PlayerControl.amplitude * Mathf.Cos(PlayerControl.period *t);

        return new Vector3(0f, vy, 0f);

    }
    public static Vector3 FlyQuad(float t, float g, float v0) {

        float vy = g * t + v0;
        if (PlayerControl.sky == true) vy = 0f;

        return new Vector3(0f, vy, 0f);

    }

    public static Vector3 RotateSine(float t) {

        // y = sinx
        float zAngle = PlayerControl.amplitude * Mathf.Cos(PlayerControl.period * t)*360;

        if (zAngle > 90)        { zAngle = 90; }
        else if (zAngle < -90)  { zAngle = -90; }

        return new Vector3(0f, 0f, zAngle);

    }
    public static Vector3 RotateQuad(float t, float g, float v0) {

        float vy = (g * t + v0);
        float zAngle = vy * 360;

        if (zAngle > 90) { zAngle = 90; }
        else if (zAngle < -90) { zAngle = -90; } // dont rotate more than -90

        return new Vector3 (0f, 0f, zAngle);

    }
    public static Vector3 RotateDive(float t, float g, float v0) {

        float vy = ( g * t + v0);
        float zAngleDef = vy * 360 + 45; // hastighet till grader, +45 för att börja rotara vid 45* (v = v0)
        float zAngle = 0f; // start angle
        float rotationSpeed = 2f; // standard = 1

        if (vy <= -v0) { zAngle += zAngleDef*rotationSpeed; } // add rotation
        if (zAngle < -90f) { zAngle = -90f; } // dont rotate more than -90

        return new Vector3(0f, 0f, zAngle);

    }

    public static Vector3 MoveX(float vx) {

        return new Vector3(-vx, 0f, 0f);

    }

}
