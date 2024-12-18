﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public int circlePoints;
    public float radius;
    public int numberOfPowerups;
    public GameObject powerUpPrefab;

    //Player Movement
    Vector3 Velocity;
    public float maxSpeed;
    public float accelerationTime;
    float acceleration;
    public float decelerationTime;
    float deAcceleration;

    //Gravity
    public List<Transform> planetTransforms;
    Vector3 planetGravity;
    int strongestPlanet;


    void Update()
    {
        if (Input.GetKey("s"))
        {
            EnemyRadar(radius, circlePoints);
        }
        if (Input.GetKeyDown("p"))
        {
            SpawnPowerups(radius, numberOfPowerups);
        }
        playerMovement();
        playerGravity();
        transform.position += Velocity * Time.deltaTime;
    }

    void playerGravity()
    {
        strongestPlanet = 0;
        for (int i = 0; i < planetTransforms.Count; i++)
        {
            if (Vector2.Distance(transform.position, planetTransforms[i].transform.position) < Vector2.Distance(transform.position, planetTransforms[strongestPlanet].transform.position))
            {
                strongestPlanet = i;
            }
        }
        Vector3 planetGravity = Vector3.Lerp(transform.position, planetTransforms[strongestPlanet].transform.position, 2*Time.deltaTime/ Vector2.Distance(transform.position, planetTransforms[strongestPlanet].transform.position));
        transform.position = planetGravity;
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
    }

    void SpawnPowerups(float radius, int numberOfPowerups)
    {
        int i;
        for (i = 0; i < numberOfPowerups; i++)
        {
            float radians = 2 * Mathf.PI / numberOfPowerups * i;

            float vertical = MathF.Sin(radians);
            float horizontal = MathF.Cos(radians);

            Vector3 spawnPoint = transform.position + new Vector3(horizontal, vertical, 0) * radius;

            Instantiate(powerUpPrefab, spawnPoint, Quaternion.identity);
        }
    }

    void EnemyRadar(float radius, int circlePoints)
    {
        if (Vector3.Distance(enemyTransform.transform.position, transform.position) < radius)
        {
            int i;
            for (i = 0; i < circlePoints; i++)
            {
                float radians1 = 2 * Mathf.PI / circlePoints * i;
                float radians2 = 2 * Mathf.PI / circlePoints * (i + 1);

                float vertical1 = MathF.Sin(radians1);
                float vertical2 = MathF.Sin(radians2);
                float horizontal1 = MathF.Cos(radians1);
                float horizontal2 = MathF.Cos(radians2);

                Vector3 linePoint1 = transform.position + new Vector3(horizontal1, vertical1, 0) * radius;
                Vector3 linePoint2 = transform.position + new Vector3(horizontal2, vertical2, 0) * radius;

                Debug.DrawLine(linePoint1, linePoint2, Color.red);

            }
        }
        else
        {
            int i;
            for (i = 0; i < circlePoints; i++)
            {
                float radians1 = 2 * Mathf.PI / circlePoints * i;
                float radians2 = 2 * Mathf.PI / circlePoints * (i + 1);

                float vertical1 = MathF.Sin(radians1);
                float vertical2 = MathF.Sin(radians2);
                float horizontal1 = MathF.Cos(radians1);
                float horizontal2 = MathF.Cos(radians2);

                Vector3 linePoint1 = transform.position + new Vector3(horizontal1, vertical1, 0) * radius;
                Vector3 linePoint2 = transform.position + new Vector3(horizontal2, vertical2, 0) * radius;

                Debug.DrawLine(linePoint1, linePoint2, Color.green);

            }
        }
    }

}
