using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacles : MonoBehaviour {

    public static int amount = 6;
    public static int spacing = 5; // stock 4
    public static int offset = 2; // // stock 3 st
    public static int verticalVariation = 2; // ???
    public static float vx = 0.05f;

    public Transform parent;
    public GameObject obstacleDuoPrefab;

    public static System.Random random = new System.Random();


    void Start () {

        // spawn obstacles
        for (int i = 0; i < amount; i++) {

            Vector3 newPosition = new Vector3(
                offset*spacing + i*spacing, // x
                random.Next(-verticalVariation, verticalVariation+2), // y
                parent.position.z); // z

            Instantiate(obstacleDuoPrefab, newPosition, Quaternion.identity, parent);
        }

    }



	
	void FixedUpdate () {


    }

}
