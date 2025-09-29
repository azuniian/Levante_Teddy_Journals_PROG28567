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

    //journal task 1 variables
    public float radarRadius;
    public int numberOfPoints;

    public List<Vector3> unitCirclePoints = new List<Vector3>();

    //journal task 2 variables
    public float powerupRadius;
    public int powerupAmount;

    public GameObject powerupPrefab;

    public List<Vector3> powerupPositions = new List<Vector3>();

    public void Start()
    {
        
    }

    void Update()
    {
        //in-class exercise/journal task 1 method call
        //DrawRadar(radarRadius, numberOfPoints);

        //journal task 2 method call
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnPowerups(powerupRadius, powerupAmount);
        }
    }


    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float powerupAngleDegrees = 360 / numberOfPowerups;

        //finding all instances of where the prefabs need to be instantiated
        for (int i = 1; i <= numberOfPowerups; i++)
        {
            float powerupX = Mathf.Cos((powerupAngleDegrees * i) * Mathf.Deg2Rad);
            float powerupY = Mathf.Sin((powerupAngleDegrees * i) * Mathf.Deg2Rad);

            Vector3 powerupPosition = new Vector3(powerupX, powerupY, 0);
            powerupPosition = (powerupPosition * radius) + transform.position;

            powerupPositions.Add(powerupPosition);
        }

        for(int i = 0; i < numberOfPowerups; i++)
        {
            GameObject currentPrefab = Instantiate(powerupPrefab, powerupPositions[i], Quaternion.identity);
            Destroy(currentPrefab, 5.0f);
        }

        powerupPositions.Clear();
    }



    //in-class exercise/journal task 1 (player radar)
    public void DrawRadar(float radius, int circlePoints)
    {
        float angleInDegrees = 360 / circlePoints;

        //finding all points in the circle and adding them to the list of points
        for(int i = 1; i <= circlePoints; i++)
        {
            //unit circle values exercise
            float unitCircleX = Mathf.Cos((angleInDegrees*i) * Mathf.Deg2Rad); //get the current unit circle x value in radians from the list
            float unitCircleY = Mathf.Sin((angleInDegrees*i) * Mathf.Deg2Rad); //get the current unit circle y value in radians from the list

            Vector3 pointOnUnitCircle = new Vector3(unitCircleX, unitCircleY, 0); //create a vector3 to hold the current x and y values from the list
            pointOnUnitCircle = (pointOnUnitCircle * radius) + transform.position; //multiply it by the circle radius to change the line length

            unitCirclePoints.Add(pointOnUnitCircle);
        }

        //drawing the radar circle
        for (int i = 0; i < circlePoints; i++)
        {
            Vector3 enemyPos = enemyTransform.position;
            float distBetween = Vector3.Distance(enemyPos, transform.position);

            if (distBetween > radius)
            {
                if (i < circlePoints - 1)
                {
                    //Debug.Log(i);
                    Debug.DrawLine(unitCirclePoints[i], unitCirclePoints[i + 1], Color.green, 15);
                }

                else if (i == circlePoints - 1)
                {
                    Debug.DrawLine(unitCirclePoints[unitCirclePoints.Count - 1], unitCirclePoints[0], Color.green, 15);
                }
            }

            else if (distBetween < radius)
            {
                if (i < circlePoints - 1)
                {
                    //Debug.Log(i);
                    Debug.DrawLine(unitCirclePoints[i], unitCirclePoints[i + 1], Color.red, 15);
                }

                else if (i == circlePoints - 1)
                {
                    Debug.DrawLine(unitCirclePoints[unitCirclePoints.Count - 1], unitCirclePoints[0], Color.red, 15);
                }
            }
            
        }
        
        unitCirclePoints.Clear();
    }


}