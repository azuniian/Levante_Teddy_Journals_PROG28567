using UnityEngine;

public class guard : MonoBehaviour
{
    public float fovAngle;
    public Transform targetTransform;
    public float coneRadius;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the angles and vectors for drawing vision cone
        //convert up direction to an angle
        float upAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.up.y, transform.up.x);

        //get right cone angle
        float rightConeAngle = upAngle - fovAngle;
        //get left cone angle
        float leftConeAngle = upAngle + fovAngle;

        //get right cone vector
        Vector3 rightConeDirection = new Vector3(Mathf.Cos(rightConeAngle * Mathf.Deg2Rad), Mathf.Sin(rightConeAngle * Mathf.Deg2Rad)); //make sure to swap the angles back to radians
        //get left cone vector
        Vector3 leftConeDirection = new Vector3(Mathf.Cos(leftConeAngle * Mathf.Deg2Rad), Mathf.Sin(leftConeAngle * Mathf.Deg2Rad));


        //detection logic
        //direction of the guard to the player
        Vector3 directionToTarget = targetTransform.position - transform.position;
        
        //get angle of guard to player
        float angleToTarget = Mathf.Rad2Deg * Mathf.Atan2(directionToTarget.y, directionToTarget.x);

        //compare the angles between the up direction and the direction to the target
        float angleDifference = Mathf.DeltaAngle(angleToTarget, upAngle);

        //get a colour to represent the change of being within the vision cone or not
        Color detectionColor;



        //test if the object is seen with angle comparison
        if(fovAngle > Mathf.Abs(angleDifference))
        {
            detectionColor = Color.green;
            //Debug.Log("target is visible");
            //Debug.Log(angleDifference);
        }
        else
        {
            detectionColor = Color.red;
            //Debug.Log("target is not visible");
        }

        //draw vision cone
        Debug.DrawLine(transform.position, (coneRadius * leftConeDirection) + transform.position, detectionColor);
        Debug.DrawLine(transform.position, (coneRadius * rightConeDirection) + transform.position, detectionColor);


    }
}
