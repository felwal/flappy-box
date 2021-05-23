using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacles : MonoBehaviour {

    public static int amount = 6;
    public static int spacing = 5;
    public static int offset = 2;
    public static int verticalVariation = 2;
    public static float vx = 0.05f;

    public Transform parent;
    public GameObject obstacleDuoPrefab;

    public static System.Random random = new System.Random();

    void Start () {

        // spawn obstacles
        for (int i = 0; i < amount; i++) {

            Vector3 newPosition = new Vector3(
                offset*spacing + i*spacing,
                random.Next(-verticalVariation, verticalVariation+2),
                parent.position.z);

            Instantiate(obstacleDuoPrefab, newPosition, Quaternion.identity, parent);
        }

    }

}
