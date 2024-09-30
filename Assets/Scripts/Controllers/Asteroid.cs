using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    bool moving;
    Vector3 movementSpot;

    private void Start()
    {
        moving = false;
    }
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
        if (moving == false)
        {
            movementSpot = new Vector2(transform.position.x+Random.Range(-maxFloatDistance, maxFloatDistance), transform.position.y+Random.Range(-maxFloatDistance, maxFloatDistance));
            moving = true;

        }

        if (moving == true)
        {
            transform.position -= Vector3.Normalize(transform.position - movementSpot) * Time.deltaTime * moveSpeed;
            if (transform.position.x < movementSpot.x + arrivalDistance && transform.position.x > movementSpot.x - arrivalDistance && transform.position.y < movementSpot.y + arrivalDistance && transform.position.y > movementSpot.y - arrivalDistance)//I hate this line
            {
                moving = false;
            }
        }
    }
}
