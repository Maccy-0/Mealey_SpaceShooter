using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    Vector3 Velocity;
    public float maxSpeed;
    public float accelerationTime;
    float acceleration;
    public float decelerationTime;
    float deAcceleration;

    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        acceleration = (maxSpeed / accelerationTime * Time.deltaTime);
        deAcceleration = -(maxSpeed / decelerationTime * Time.deltaTime);

        if (Input.GetKey("up"))
        {
            Velocity += new Vector3(0, acceleration);
            if (Velocity.y > maxSpeed)
            {
                Velocity.y = maxSpeed;
            }
        }
        else
        {
            if (Velocity.y > 0)
            {
                Velocity += new Vector3(0, deAcceleration);
            }
        }
        if (Input.GetKey("down"))
        {
            Velocity += new Vector3(0, -acceleration);
            if (Velocity.y < -maxSpeed)
            {
                Velocity.y = -maxSpeed;
            }
        }
        else
        {
            if (Velocity.y < 0)
            {
                Velocity += new Vector3(0, -deAcceleration);
            }
        }
        if (Input.GetKey("left"))
        {
            Velocity += new Vector3(-acceleration, 0);
            if (Velocity.x < -maxSpeed)
            {
                Velocity.x = -maxSpeed;
            }
        }
        else
        {
            if (Velocity.x < 0)
            {
                Velocity += new Vector3(-deAcceleration, 0);
            }
        }
        if (Input.GetKey("right"))
        {
            Velocity += new Vector3(acceleration, 0);
            if (Velocity.x > maxSpeed)
            {
                Velocity.x = maxSpeed;
            }
        }
        else
        {
            if (Velocity.x > 0)
            {
                Velocity += new Vector3(deAcceleration, 0);
            }
        }

        transform.position += Velocity * Time.deltaTime;
    }
}
