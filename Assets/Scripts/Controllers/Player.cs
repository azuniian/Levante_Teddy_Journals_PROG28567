using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //vector mechanic proposal variables
    public TMPro.TMP_InputField pointsInputField;

    public float shieldRadius;
    public int numberOfPoints;
    public float timeToWait;

    public List<Vector3> unitCirclePoints = new List<Vector3>();

    private IEnumerator drawCoroutine;
    public bool coroutineStopped = false;



    //rotation mechanic proposal variables
    public TMPro.TMP_InputField projectileInputField;

    public GameObject projectilePrefab;
    public Transform projectileTransform;
    public Vector3 projectileStartPos;
    public float rotationRadius;
    public float rotationSpeed;
    public int numberOfProjectiles;

    public List<GameObject> projectilesSpawned = new List<GameObject>();



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

        projectileRotation();

    }



    public void projectileRotation()
    {
        //get the projectile starting position for when it spawns - want this at the top so that if the player ship is moved, it will update before spawning
        projectileStartPos = transform.position + Vector3.up * rotationRadius;
        
        //check for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space pressed");

            //first, get the amount of projectiles
            if (int.TryParse(projectileInputField.text, out int projectiles) && projectiles > 0)
            {
                //set the projectiles value to a variable, then use it to spawn the correct number of projectiles in front of the player ship
                numberOfProjectiles = projectiles;
                
                for (int i = 0; i < numberOfProjectiles; i++)
                {
                    GameObject newProjectile = Instantiate(projectilePrefab, projectileStartPos, Quaternion.identity);
                    projectilesSpawned.Add(newProjectile);
                    Debug.Log("spawned projectiles"); 
                }

            }
        }

        
        //actual rotation happens with transform.Rotate() function
        for (int i = 0; i < numberOfProjectiles; i++) 
        {
            float angleToChange = -rotationSpeed * Time.deltaTime;
            //Debug.Log(angleToChange);
            //need to rotate each projectile in the list
            projectilesSpawned[i].transform.Rotate(0f, 0f, angleToChange);
            //Debug.Log(projectilesSpawned[i].transform.position);
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


        //find the amount of sides that need to be drawn
        float tempNumberOfSides = unitCirclePoints.Count;
        if(tempNumberOfSides%2 == 0) //even
        {
            int setsOfSides = (int)(tempNumberOfSides/2);
            Debug.Log(setsOfSides);
            Debug.Log("even");
            bool evenNumber = true;
        }
        else //odd
        {
            int setsOfSides = (int)((tempNumberOfSides / 2) + 1);
            Debug.Log(setsOfSides);
            Debug.Log("odd");
            bool evenNumber = false;
        }


        int j = 0;
        while (j < points)
        {
            if (j < points - 1)
            {
                //Debug.Log(i);
                Debug.DrawLine(unitCirclePoints[j] + transform.position, unitCirclePoints[j + 1] + transform.position, Color.green, 3);
            }

            else if (j == points - 1)
            {
                Debug.DrawLine(unitCirclePoints[unitCirclePoints.Count - 1] + transform.position, unitCirclePoints[0] + transform.position, Color.green, 3);
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
