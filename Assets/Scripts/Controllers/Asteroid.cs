using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    // Start is called before the first frame update
    void Start()
    {
        bool firstPointFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        AsteroidMovement();

    }

    public void AsteroidMovement()
    {
        Vector3 randomDirection = Vector3.zero;
        Vector3 position = transform.position;


        Vector3 randomDirectionVector = new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
        randomDirection = randomDirectionVector;
        randomDirection = randomDirection.normalized;
        randomDirection = randomDirection * maxFloatDistance;


        //using https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
        float distanceBetween = Vector3.Distance(position, randomDirection); //find the entire distance needing to be travelled
        float distanceCovered = Time.deltaTime * moveSpeed; //speed times the time spent moving to find how much of the distance has been covered


        //if the asteroid has reached the area considered within the arrival distance
        if (distanceBetween <= arrivalDistance)
        {
            //Debug.Log("in range");
            //find new random point
            randomDirectionVector = new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
            randomDirection = Vector3.zero;
        }

        //if the asteroid has NOT reached the area considered within the arrival distance
        else if (distanceBetween > arrivalDistance)
        {
            //move towards the chosen random point
            transform.position = Vector3.Lerp(position, randomDirection, (distanceCovered / distanceBetween));
            //transform.position += randomDirection*moveSpeed;
        }
    }
}
