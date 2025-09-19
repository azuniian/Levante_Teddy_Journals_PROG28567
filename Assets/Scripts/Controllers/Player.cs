using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //journal 3 variables
    public Vector3 velocityX = new Vector3(0.5f, 0, 0);
    public Vector3 velocityY = new Vector3(0, 0.5f, 0);

    private float acceleration;

    public float accelerationTime = 3;
    public float maxSpeed = 5f;


    private void Start()
    {
        //acceleration = velocity/time
        acceleration = (maxSpeed / accelerationTime);

        //velocityX = Vector3.right * Time.deltaTime;
        //velocityY = Vector3.up * Time.deltaTime;
    }

    void Update()
    {

        //movement & acceleration for left direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 direction = Vector3.zero;

            //increase velocity to the left by increasing acceleration? no! instead, store a direction variable and increase the direction value
            direction += Vector3.left;
            direction = direction.normalized;

            if(velocityX.x > -maxSpeed)
            {
                velocityX.x += direction.x * acceleration * Time.deltaTime;
            }

            Debug.Log(velocityX.x);

            PlayerMovement(1, velocityX);
        }
        //decceleration
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            velocityX.x = 0;
        }


        //movement and acceleration for right direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 direction = Vector3.zero;

            //increase velocity to the right
            direction += Vector3.right;
            direction = direction.normalized;

            if (velocityX.x < maxSpeed)
            {
                velocityX.x += direction.x * acceleration * Time.deltaTime;
            }

            Debug.Log(velocityX.x);

            PlayerMovement(2, velocityX);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            velocityX.x = 0;
        }


        //movement and acceleration for up direction
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 direction = Vector3.zero;

            //increase velocity up
            direction += Vector3.up;
            direction = direction.normalized;

            if (velocityY.y < maxSpeed)
            {
                velocityY.y += direction.y * acceleration * Time.deltaTime;
            }

            Debug.Log(velocityY.y);

            PlayerMovement(3, velocityY);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            velocityY.y = 0;
        }


        //movement and acceleration for down direction
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 direction = Vector3.zero;

            //increase velocity down
            direction += Vector3.down;
            direction = direction.normalized;

            if (velocityY.y > -maxSpeed)
            {
                velocityY.y += direction.y * acceleration * Time.deltaTime;
            }

            Debug.Log(velocityY.y);

            PlayerMovement(4, velocityY);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            velocityY.y = 0;
        }

    }


    public void PlayerMovement(float whichDirection, Vector3 inVelocity)
    {
        if (whichDirection == 1)
        {
            /*//move left
            inVelocity.x += accelerationX;
            transform.position -= inVelocity;*/

            transform.position += inVelocity;

        }

        if (whichDirection == 2)
        {
            //move right
            transform.position += inVelocity;
        }

        if (whichDirection == 3)
        {
            //move up
            transform.position += inVelocity;
        }

        if (whichDirection == 4)
        {
            //move down
            transform.position += inVelocity;
        }

    }

}
