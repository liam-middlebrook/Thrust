﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class ShipMovement : MonoBehaviour {

    public Vector2 offset;
    Controller controller;

    public void Start()
    {
        controller = GetComponent<Controller>();
    }

    public void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Vector2 position = new Vector2();
            foreach(Touch touch in Input.touches)
            {
                position += touch.position;
            }
            position /= Input.touchCount;
            position += offset;

            float maxLeft = Camera.main.orthographicSize * Camera.main.aspect - controller.SpriteHalfWidth;
            float maxTop = Camera.main.orthographicSize - controller.SpriteHalfHeight;
            if (position.x > maxLeft)
            {
                position.x = maxLeft;
            }
            else if (position.x < -maxLeft)
            {
                position.x = -maxLeft;
            }
            else if (position.y > maxTop)
            {
                position.y = maxTop;
            }
            else if (position.y < -maxTop)
            {
                position.y = -maxTop;
            }

            controller.MovePosition(position);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position += offset;
            float maxLeft = Camera.main.orthographicSize * Camera.main.aspect - controller.SpriteHalfWidth;
            float maxTop = Camera.main.orthographicSize - controller.SpriteHalfHeight;
            if (position.x > maxLeft)
            {
                position.x = maxLeft;
            }
            else if (position.x < -maxLeft)
            {
                position.x = -maxLeft;
            }
            else if (position.y > maxTop)
            {
                position.y = maxTop;
            }
            else if (position.y < -maxTop)
            {
                position.y = -maxTop;
            }

            controller.MovePosition(position);
        }
    }
}