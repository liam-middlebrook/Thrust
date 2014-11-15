﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector2 target;
    public Controller controller;

    public float lifeTimer;
    public float timeAlive;

    //Used for curved shots only
    public float angle = 0;
    public float rotationalVelocity = 0;
    public float bulletSpeed = 5;

	// Use this for initialization
	void Start () 
    {
        controller = GetComponent<Controller>();
        //angle = Vector2.Angle(, target);
	}
	
	// Update is called once per frame
	void Update () 
    {
        controller.Translate(target*bulletSpeed);

        if (timeAlive >= lifeTimer)
        {
            controller.Die();
        }
        timeAlive += Time.deltaTime;
	}
}
