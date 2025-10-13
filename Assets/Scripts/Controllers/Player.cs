using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

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

    private IEnumerator spawnCoroutine;
    public float waitingTime;

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

                //find the amount of time to wait between spawning projectiles
                //get circumference of circle based on radius
                float pi = Mathf.PI;
                float circumference = 2 * pi * rotationRadius;
                //find the distance between each projectile
                float distBetweenProjectiles = circumference / numberOfProjectiles;
                //find the time it takes to get to that point by using the speed formula and rearranging
                //velocity formula is s = d/t where s = speed, d = distance and t = time
                //therefore it should be time = distance/speed
                waitingTime = distBetweenProjectiles / rotationSpeed;

                spawnCoroutine = spawnProjectiles(projectiles, waitingTime);
                StartCoroutine(spawnProjectiles(projectiles, waitingTime));
            }
        }

        foreach(GameObject projectile in projectilesSpawned)
        {
            Vector3 targetVector = transform.position;
            //get a direction
            Vector3 direction = Vector3.zero;
            direction = projectile.transform.position - targetVector;
            direction = direction.normalized;
            //Debug.DrawLine(Vector3.zero, direction);

            //use atan2 to find the angle
            float angleInRadians = Mathf.Atan2(direction.y, direction.x);

            //multiply the angle by the speed so it knows how much to change
            angleInRadians += -rotationSpeed * Time.deltaTime;

            //third time's the charm! had to find the new point by using the angle found with the direction vector and atan2
            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            //put the x and y into a new Vector3
            Vector3 orbitPos = new Vector3(x, y, 0);
            //THEN multiply by the radius to ensure that the radius is included, then add the targetVector to make sure that it is actually orbiting the planet
            orbitPos = (orbitPos * rotationRadius) + targetVector;

            //reset the position
            projectile.transform.position = orbitPos;
        }
        
    }


    private IEnumerator spawnProjectiles(float projectileAmount, float time)
    {
        int i = 0;
        while (i < projectileAmount)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, projectileStartPos, Quaternion.identity);
            projectilesSpawned.Add(newProjectile);
            Debug.Log("spawned projectiles");

            yield return new WaitForSeconds(time);
            i++;
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
