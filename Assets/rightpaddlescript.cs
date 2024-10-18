using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightpaddlescript : MonoBehaviour
{
    // Player movement via WASD!
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }


        float dt = Time.deltaTime;
        float speed = 10.0f;
        Vector3 change = direction * speed * dt;
        transform.position = transform.position + change;
    }
}
