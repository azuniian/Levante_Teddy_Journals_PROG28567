using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed;
    public Transform targetTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);

        Vector3 directionToTarget = targetTransform.position - transform.position;


        float dotProduct = Vector3.Dot(transform.right, directionToTarget);
        float currentAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.up.y, transform.up.x);
        float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(directionToTarget.y, directionToTarget.x);

        float angleRemaining = Mathf.DeltaAngle(currentAngle, targetAngle);
        float changeInAngle;

        //If dot product is positive
        //The object is on the right hand side and we should rotate to the right
        if (dotProduct > 0)
        {
            //Negative will rotate to the right
            changeInAngle = -angularSpeed * Time.deltaTime;

            //If the change that we're about to do would overshoot
            if (changeInAngle < angleRemaining)
            {
                //Snap to the target
                transform.Rotate(0f, 0f, angleRemaining);
            }
            else //If it wouldn't overshoot
            {
                //Rotate as normal
                transform.Rotate(0f, 0f, changeInAngle);
            }


        }
        else
        {
            changeInAngle = angularSpeed * Time.deltaTime;
            //Move to the left
            if (changeInAngle > angleRemaining)
            {
                transform.Rotate(0f, 0f, angleRemaining);
            }
            else
            {
                transform.Rotate(0f, 0f, changeInAngle);
            }
        }


        ////////////////////////////EXERCISE FOR ROTATING WITH ANGULAR SPEED\\\\\\\\\\\\\\\\\\\\\\\\
        ////this part works fine - just rotates itself through the method
        //transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        ////same here - draws a line from the object to its up direction
        //Debug.DrawLine(transform.position, transform.up, Color.green);

        //MY ATTEMPT AT THE STOP ROTATION LOGIC
        ////this part is where i'm struggling at the moment - i need to fix my conditional logic so that it will actually stop rotating once it gets to a specific angle
        //float currentRotationAngle = Mathf.Atan2(transform.up.y, transform.up.x); //make an angle out of a vector
        //float currentRotationAngleDegrees = currentRotationAngle * Mathf.Rad2Deg; //convert it to degrees
        ////Debug.Log(currentRotationAngleDegrees);

        //if(currentRotationAngleDegrees > 81 && currentRotationAngleDegrees < 82)
        //{
        //    angularSpeed = 0;
        //}
    }
}
