using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public bool firstPointFound;

    // Start is called before the first frame update
    void Start()
    {
        firstPointFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomDirection = Vector3.zero;
        Vector3 position = transform.position;
        Vector3 randomDirectionVector;

        //if there is no current randomDirection chosen since the code hasn't started yet
        if(firstPointFound == false)
        {
            randomDirectionVector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            randomDirection += randomDirectionVector;
            randomDirection = randomDirection.normalized;
            firstPointFound = true;
        }
        

        //using https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
        float distanceBetween = Vector3.Distance(position, randomDirection*maxFloatDistance); //find the entire distance needing to be travelled
        float distanceCovered = Time.deltaTime * moveSpeed; //speed times the time spent moving to find how much of the distance has been covered


        //if the asteroid has reached the area considered within the arrival distance
        if(distanceBetween <= arrivalDistance)
        {
            //find new random point
            randomDirectionVector = new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
            randomDirection = Vector3.zero;
            randomDirection += randomDirectionVector;
            randomDirection = randomDirection.normalized;

            //find new distance between
            distanceBetween = Vector3.Distance(position, randomDirection * maxFloatDistance);
            
        }

        //if the asteroid has NOT reached the area considered within the arrival distance
        else if(distanceBetween > arrivalDistance)
        {
            //move towards the chosen random point
            transform.position = Vector3.Lerp(position, randomDirection, (distanceCovered / distanceBetween));
        }

        
        
        

    }
}
