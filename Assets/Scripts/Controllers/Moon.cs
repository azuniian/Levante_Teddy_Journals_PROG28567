using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitRadius;
    public float orbitSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        Vector3 targetVector = target.position;
        //get a direction
        Vector3 direction = Vector3.zero;
        direction = transform.position - targetVector;
        direction = direction.normalized;
        //Debug.DrawLine(Vector3.zero, direction);

        //use atan2 to find the angle
        float angleInRadians = Mathf.Atan2(direction.y, direction.x);

        //multiply the angle by the speed so it knows how much to change
        angleInRadians += speed * Time.deltaTime;

        //third time's the charm! had to find the new point by using the angle found with the direction vector and atan2
        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);

        //put the x and y into a new Vector3
        Vector3 orbitPos = new Vector3(x, y, 0);
        //THEN multiply by the radius to ensure that the radius is included, then add the targetVector to make sure that it is actually orbiting the planet
        orbitPos = (orbitPos * radius) + targetVector;

        //reset the position
        transform.position = orbitPos;



        ////first attempt at the math...may have incorporated the radius wrong?
        ////move the moon's position by the direction in the angle??
        ////find the new coordinates
        //float orbitedX = Mathf.Cos(angleInRadians);
        //float orbitedY = Mathf.Sin(angleInRadians);

        ////create a Vector3 for the new point coordinates
        //Vector3 afterOrbit = new Vector3(orbitedX, orbitedY, 0);
        //afterOrbit = afterOrbit * radius;

        ////set transform.position to afterOrbit transform to get position
        //transform.position += afterOrbit;


        //second attempt - tried to ask kano for help, as his code was working. the way he described it made it seem like this? however...also not working, but worse than last time
        //float orbitedX = targetVector.x + radius * Mathf.Cos(angleInRadians);
        //float orbitedY = targetVector.y + radius * Mathf.Sin(angleInRadians);

        //transform.position = new Vector3(orbitedY, orbitedX, 0);
        ////transform.position = afterOrbit;


    }


}
