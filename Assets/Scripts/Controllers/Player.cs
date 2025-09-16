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
    public Vector3 velocityY;

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


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 direction = Vector3.zero;

            //increase velocity to the left by increasing acceleration? no! instead, store a direction variable and increase the direction value
            direction += Vector3.left;
            direction = direction.normalized;
            velocityX.x += direction.x * acceleration * Time.deltaTime;

            Debug.Log(velocityX.x);

            PlayerMovement(1, velocityX);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMovement(2, velocityX);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMovement(3, velocityY);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerMovement(4, velocityY);
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
            /*//move right
            transform.position += inVelocity;*/
        }

        if (whichDirection == 3)
        {
            /*//move up
            transform.position += inVelocity;*/
        }

        if (whichDirection == 4)
        {
            /*//move down
            transform.position -= inVelocity;*/
        }

    }

}
