using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDuo : MonoBehaviour {

    bool passed;

    public GameObject player;
    public GameObject obstacleDuo;
    Vector3 spawnPosition;

    void Start () {

        spawnPosition = obstacleDuo.transform.position;

    }
    private void FixedUpdate() {

        // movement x
        switch (PlayerControl.gameMode) {
            case 0: obstacleDuo.transform.position = spawnPosition; passed = false; break; // spawn
            case 1: obstacleDuo.transform.position += FlyPhysics.MoveX(Obstacles.vx); break; // move x
            case 2: break;
            case 3: break;
        }

        // respawn
        if (obstacleDuo.transform.position.x <= -Obstacles.spacing * Obstacles.offset) {
            obstacleDuo.transform.position = RespawnPosition();
            passed = false;
        }

        // add score
        if (obstacleDuo.transform.position.x <= player.transform.position.x && passed == false) {
            PlayerControl.score++;
            passed = true;
        }

    }

    public Vector3 RespawnPosition() {

        Vector3 respawnPosition = new Vector3(
            Obstacles.amount * Obstacles.spacing - Obstacles.spacing * Obstacles.offset, // x
            Obstacles.random.Next(-Obstacles.verticalVariation, Obstacles.verticalVariation + 2), // y
            spawnPosition.z); // z

        return respawnPosition;
    }

}
