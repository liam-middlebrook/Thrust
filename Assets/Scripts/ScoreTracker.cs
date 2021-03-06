﻿using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
    GUIText text;
    StarfieldScrolling stars;
    // Use this for initialization
	void Start () {
        text = GetComponent<GUIText>();
        stars = GameObject.Find("MasterStarField").GetComponent<StarfieldScrolling>();
        GameManager.SharedManager.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Distance Traveled: " + Mathf.Round(GameManager.SharedManager.lastScore * 10) / 10;
	}

    void FixedUpdate()
    {
        GameManager.SharedManager.lastScore += stars.Speed;
    }
}
