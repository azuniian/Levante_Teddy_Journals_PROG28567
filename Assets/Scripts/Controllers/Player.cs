using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public TMPro.TMP_InputField pointsInputField;

    public float shieldRadius;
    public int numberOfPoints;
    public float timeToWait;

    public List<Vector3> unitCirclePoints = new List<Vector3>();

    private IEnumerator drawCoroutine;
    public bool coroutineStopped = false;

    public void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //check for mouse click
        {
            Debug.Log("mouse clicked");

            if (float.TryParse(pointsInputField.text, out float points) && points >= 0) //check to ensure that the value in the box is a valid number for the math
            {
                drawCoroutine = drawSections(points, timeToWait);
                StartCoroutine(drawSections(points, timeToWait));
            }

        }

    }


    private IEnumerator drawSections(float points, float time)
    {
        Debug.Log("running");
        float angleInDegrees = 360 / points; //get the angle needed for drawing each line segment in degrees
        int i = 1;

        while (i <= points)
        {
            //unit circle values exercise
            float unitCircleX = Mathf.Cos((angleInDegrees * i) * Mathf.Deg2Rad); //get the current unit circle x value in radians from the list
            float unitCircleY = Mathf.Sin((angleInDegrees * i) * Mathf.Deg2Rad); //get the current unit circle y value in radians from the list

            Vector3 pointOnUnitCircle = new Vector3(unitCircleX, unitCircleY, 0); //create a vector3 to hold the current x and y values from the list
            pointOnUnitCircle = pointOnUnitCircle * shieldRadius; //multiply it by the circle radius to change the line length

            unitCirclePoints.Add(pointOnUnitCircle);
            i++;
        }

        int j = 0;
        while (j < points)
        {
            if (j < points - 1)
            {
                //Debug.Log(i);
                Debug.DrawLine(unitCirclePoints[j], unitCirclePoints[j + 1], Color.green, 5);
            }

            else if (j == points - 1)
            {
                Debug.DrawLine(unitCirclePoints[unitCirclePoints.Count - 1], unitCirclePoints[0], Color.green, 5);
            }
            j++;
            yield return new WaitForSeconds(time);
        }

        //clear so that this can all be re-used
        unitCirclePoints.Clear();

        //yield return null;
        StopCoroutine(nameof(drawSections));
    }
}
