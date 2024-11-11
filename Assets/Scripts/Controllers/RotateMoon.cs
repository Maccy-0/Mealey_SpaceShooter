using Codice.CM.Client.Differences;
using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    public Transform planet;
    Vector3 Velocity;
    public float Speed;

    private void Start()
    {
        Velocity = new Vector2(Random.Range(-0.04f, 0.04f), Random.Range(-0.04f, 0.04f));
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        Velocity += Vector3.Normalize(transform.position - planet.position) * Time.deltaTime * Speed;

        transform.position -= Velocity;
    }
}
