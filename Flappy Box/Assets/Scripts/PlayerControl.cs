using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float g = -0.25f; // stock -0.25
    public float v0 = 0.125f; // stock 0.125
    public static float amplitude = 0.02f;
    public static float period = 4;

    float t;
    public static int gameMode = 0;

    public static int score = 0;
    public static int scoreHigh = 0;

    public Transform player;
    Vector3 startPosition;

    public static bool sky; //


    void Start () {

        // set start
        startPosition = player.position;

    }

    void FixedUpdate () {

        t += Time.deltaTime;

        // movement y + rotation z
        switch (gameMode) {

            case 0:
                player.position += FlyPhysics.flySine(t); // fly
                //player.eulerAngles = FlyPhysics.rotateSine(t); // rotate
                break;
            case 1:
                player.position += FlyPhysics.flyQuad(t, g, v0);
                //player.eulerAngles = FlyPhysics.rotateQuad(t, g, v0);
                break;
            case 2:
                player.position += FlyPhysics.flyQuad(t, g, 0f);
                player.eulerAngles = new Vector3(0f, 0f, -90f);
                break;
            case 3: break;
        }

        // change gamemode, jump
        if (Input.anyKeyDown) {

            switch (gameMode) {

                case 0: // jump + start game
                    t = 0; gameMode = 1;
                    break; 
                case 1: // jump
                    t = 0;
                    break; 
                case 2: // move to ground
                    player.position = new Vector3(player.position.x, -3.5f, player.position.z);
                    gameMode = 3;
                    break; 
                case 3:  // reset game
                    t = 0;
                    player.position = startPosition;
                    gameMode = 0;
                    if (score > scoreHigh) { scoreHigh = score; } score = 0;
                    break;
            }
        } 


    }

    private void OnCollisionEnter2D(Collision2D other) {

        if      (other.gameObject.tag == "Obstacle") { if (gameMode != 2)   { gameMode = 2; t = 0; } }  
        else if (other.gameObject.tag == "Ground")                          { gameMode = 3; }
        else if (other.gameObject.tag == "Skybox") { sky = true; }

    }
    private void OnCollisionExit2D(Collision2D other) {

        if (other.gameObject.tag == "Skybox") { sky = false; }

    }
    

}

// random float
// pause, restart
// skybox
// understand rotations
// save data