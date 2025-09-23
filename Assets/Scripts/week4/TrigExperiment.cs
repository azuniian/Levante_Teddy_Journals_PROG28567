using UnityEngine;
using System.Collections.Generic;

public class TrigExperiment : MonoBehaviour
{
    public List<float> anglesInDegrees = new List<float>();
    public int i = 0;
    public float circleRadius;
    public float newOriginX;
    public float newOriginY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if i was to add to the list, this is the syntax
        //anglesInDegrees.Add(25);
        

        //draw a line towards an angle in class exercise
        float angleInDegrees = -45f;
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        float angleInDegreesAgain = angleInRadians * Mathf.Rad2Deg;

        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);


        //float angleFromInverseFunction = Mathf.Asin(y / 1) * Mathf.Rad2Deg;
        //Debug.Log("original angle: " + angleInDegrees + " angle from inverse function: " + angleFromInverseFunction);

        //starting with x and y, want to convert back to angle value
        float convertedAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        Debug.Log("original angle: " + angleInDegrees + " angle from inverse function: " + convertedAngle);


        Vector3 pointOnCircle = new Vector3(x, y, 0);
        Debug.DrawLine(Vector3.zero, pointOnCircle, Color.red, 15);
    }

    // Update is called once per frame
    void Update()
    {
        //unit circle value exercises
        if (Input.GetKeyDown(KeyCode.Space)) //check for space press
        {
            if (i < anglesInDegrees.Count) //if the index is still valid
            {
                //unit circle values exercise
                float unitCircleX = Mathf.Cos(anglesInDegrees[i] * Mathf.Deg2Rad); //get the current unit circle x value in radians from the list
                float unitCircleY = Mathf.Sin(anglesInDegrees[i] * Mathf.Deg2Rad); //get the current unit circle y value in radians from the list

                Vector3 pointOnUnitCircle = new Vector3(unitCircleX, unitCircleY, 0); //create a vector3 to hold the current x and y values from the list
                pointOnUnitCircle = pointOnUnitCircle * circleRadius; //multiply it by the circle radius to change the line length
                Vector3 newOrigin = new Vector3(newOriginX, newOriginY, 0); //create a vector3 to hold the center circle position x and y values from the inspector

                Debug.DrawLine(newOrigin, Vector3.zero, Color.red, 15); //for debugging - draw a line from the origin to the new circle position
                Debug.DrawLine(Vector3.zero + newOrigin, pointOnUnitCircle + newOrigin, Color.blue, 5); //ENSURE THAT BOTH POINTS ARE OFFSET BY THE NEW CIRCLE CENTER POSITION!! draw a line between the circle center and the unit circle point
                i++; //add to the index so the next space button press draws the next line
            }

            else //if the index is not valid
            {
                i = 0; //reset the index
            }
        }

    }
}
