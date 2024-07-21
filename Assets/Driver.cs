using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerSpeed = 260;
    float moveSpeed = 18;

    float slowSpeed = 15;
    float boostSpeed = 21;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; //Constantly need to update as player will do or not do steer
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            moveSpeed = 18;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            moveSpeed = slowSpeed;
        }
    }
}
