using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Vector3 velocity;

    private float acceleration;

    public float accelerationTime = 3;
    public float decelerationTime = 1;
    public float maxSpeed = 5f;

    public Transform playerPos;

    public float arrivalDist = 0.5f;

    public List<Vector3> warpPositions = new List<Vector3>();
    

    void Start()
    {
        acceleration = (maxSpeed / accelerationTime);

        for (float i = 0;  i < warpPositions.Count; i += i*Time.deltaTime)
        {
            int j = (int)i;
            transform.position = warpPositions[j];
        }
    }

    void Update()
    {
        

        Vector3 direction = Vector3.zero;
        Vector3 playerVector = new Vector3(playerPos.position.x, playerPos.position.y, 0);
        direction = playerVector - transform.position;
        direction = direction.normalized;

        //Debug.DrawLine(Vector3.zero, direction, Color.white);

        if(Vector3.Distance(transform.position, playerPos.position) >= arrivalDist)
        {
            velocity += direction * acceleration * Time.deltaTime;
            transform.position += velocity;
        }

        else
        {
            //Debug.Log("stopping");
            velocity = Vector3.zero;
        }
        


    }

}
