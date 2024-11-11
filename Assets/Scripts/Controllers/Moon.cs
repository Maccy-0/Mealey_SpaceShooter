using Codice.CM.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{
    public float radius;
    public float orbitalspeed;
    public Transform target;
    float placeInOrbit;

    // Start is called before the first frame update
    void Start()
    {
        placeInOrbit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, orbitalspeed, target);
    }

    void OrbitalMotion(float radius, float speed, Transform target)
    {
        placeInOrbit = (placeInOrbit + speed*Time.deltaTime) % 100;

        float radians = 2 * Mathf.PI / 100 * placeInOrbit;

        float vertical = MathF.Sin(radians);
        float horizontal = MathF.Cos(radians);

        transform.position = target.transform.position + new Vector3(horizontal, vertical, 0) * radius;
    }
}
