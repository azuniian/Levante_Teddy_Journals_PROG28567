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

    public float radarRadius;
    public int numberOfPoints;

    public List<Vector3> unitCirclePoints = new List<Vector3>();

    public void Start()
    {
        
    }

    void Update()
    {
        //in-class exercise/journal 1 method call
        DrawRadar(radarRadius, numberOfPoints);
    }



    //in-class exercise (player radar)
    public void DrawRadar(float radius, int points)
    {
        float angleInDegrees = 360 / points;

        for(int i = 1; i <= points; i++)
        {
            //unit circle values exercise
            float unitCircleX = Mathf.Cos((angleInDegrees*i) * Mathf.Deg2Rad); //get the current unit circle x value in radians from the list
            float unitCircleY = Mathf.Sin((angleInDegrees*i) * Mathf.Deg2Rad); //get the current unit circle y value in radians from the list

            Vector3 pointOnUnitCircle = new Vector3(unitCircleX, unitCircleY, 0); //create a vector3 to hold the current x and y values from the list
            pointOnUnitCircle = pointOnUnitCircle * radius; //multiply it by the circle radius to change the line length

            unitCirclePoints.Add(pointOnUnitCircle);
        }

        for (int i = 0; i < points; i++)
        {
            if( i < points - 1)
            {
                //Debug.Log(i);
                Debug.DrawLine(unitCirclePoints[i], unitCirclePoints[i+1], Color.green, 15);
            }
            
            else if(i == points - 1)
            {
                Debug.DrawLine(unitCirclePoints[unitCirclePoints.Count - 1], unitCirclePoints[0], Color.green, 15);
            }
        }
        
        unitCirclePoints.Clear();
    }


}