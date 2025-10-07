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
        //draw a line between object and target
        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);
        Vector3 directionToTarget = targetTransform.position - transform.position;

        //can't use the dot product of the object's position and transform.right since itll only return moving left if the object is on the left side of the screen
        //instead, use the DIRECTION VECTOR between the target's transform and the object's position and transform.right
        float dotProduct = Vector3.Dot(transform.right, directionToTarget);

        if(dotProduct > 0) //if positive, move to the right
        {
            float currentAngle = (Mathf.Atan2(transform.up.y, transform.up.x)) * Mathf.Rad2Deg;
            float targetAngle = (Mathf.Atan2(directionToTarget.y, directionToTarget.x)) * Mathf.Rad2Deg;

            float remainingAngle = Mathf.DeltaAngle(currentAngle, targetAngle);
            float changeInAngle = -angularSpeed * Time.deltaTime;

            if (changeInAngle > remainingAngle)
            {
                transform.Rotate(0f, 0f, remainingAngle);
            }
            else
            {
                transform.Rotate(0f, 0f, changeInAngle);
            }
        }

        else //if negative, move to the left
        {
            

            //if ()
            //{
            //    transform.Rotate(0f, 0f, angularSpeed);
            //}
            //else
            //{
            //    transform.rotation = targetTransform.rotation;
            //}
            
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
