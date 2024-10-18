using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public GameObject LeftPaddle;

    public GameObject RightPaddle;

    int p1score = 0;
    int p2score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Uncomment to change direction of the ball using trigonometry
        float angle = (Random.Range(0.0f, 45.0f)) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Homework: Prevent the ball from travelling off the screen by changing its direction

        // If the ball is too far right, make its x-direction negative (1% -- free)
        if (transform.position.x > 7.5f)
        {
            //player 1 scores
            //add 1 to player score, print score to screen, reset ball position
            p1score++;
            Debug.Log("Score - P1: " + p1score + " P2: " + p2score);
            transform.position = new Vector2(0.0f, 0.0f);
            float angle = (Random.Range(0.0f, 360.0f)) * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        // If the ball is too far left, make its x-direction positive (1%)
        if (transform.position.x < -7.5f)
        {
            //player 2 scores
            p2score++;
            Debug.Log("Score - P1: " + p1score + " P2: " + p2score);
            transform.position = new Vector2(0.0f, 0.0f);
            float angle = (Random.Range(0.0f, 360.0f)) * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        // If the ball is too far up, make its y-direction negative (1%)
        if (transform.position.y > 4.5f)
        {
            direction.y = -direction.y;
        }
        // If the ball is too far down, make its y-direction positive (1%)
        if (transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
        }

        if (transform.position.x > LeftPaddle.transform.position.x && transform.position.x < LeftPaddle.transform.position.x + 0.75)
        {
            if (transform.position.y < LeftPaddle.transform.position.y + 1.5f && transform.position.y > LeftPaddle.transform.position.y - 1.5f)
            {
                direction.x = -direction.x;
            }
        }

        if (transform.position.x < RightPaddle.transform.position.x && transform.position.x > RightPaddle.transform.position.x - 0.75)
        {
            if (transform.position.y > RightPaddle.transform.position.y - 1.5f && transform.position.y < RightPaddle.transform.position.y + 1.5f)
            {
                direction.x = -direction.x;
            }
        }


        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;
    }
    Vector2 direction = Vector2.right;
    float speed = 5.0f;
}