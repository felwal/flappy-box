using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public UnityEngine.UI.Text scoreDisplay;
    public UnityEngine.UI.Text scoreHighDisplay;

	void Update () {

        scoreDisplay.text = PlayerControl.score.ToString();
        scoreHighDisplay.text = PlayerControl.scoreHigh.ToString();

    }

}
