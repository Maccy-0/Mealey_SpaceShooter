using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 Velocity;
    public float Speed;

    private void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        Velocity += Vector3.Normalize(transform.position - playerTransform.position) * Time.deltaTime*Speed;
        
        transform.position -= Velocity;
    }


}
