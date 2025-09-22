using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 5;

    public float acceleration;
    public float drawSpeed = 3;

    private void Start()
    {
        acceleration = drawSpeed / drawingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawConstellation();
        }
    }

    public void DrawConstellation()
    {

        for(int i = 0; i < starTransforms.Count; i++)
        {
            float distance = Vector3.Distance(starTransforms[i].position, starTransforms[i + 1].position);
            
            //create direction vector between the two stars and then normalize it to get a magnitude of 1
            Vector3 direction = (starTransforms[i].position - starTransforms[i+1].position).normalized;

            //create velocity vector and update it with acceleration logic
            Vector3 velocity = direction * acceleration * Time.deltaTime;

            //multiply by the normalized direction vector by the velocity until the magnitude of the direction vector is >= the distance between the stars
            if(direction.magnitude < distance)
            {
                float distCovered = Time.deltaTime * drawSpeed;
                Vector3 currentPos = Vector3.Lerp(starTransforms[i].position, starTransforms[i + 1].position, distCovered / distance);
                Debug.DrawLine(starTransforms[i].position, currentPos);
            }
            //draw the line with each different velocity value (each time the acceleration is added to the velocity
            
        }

        //Vector3 currentStar = starTransforms[i].position;
        //Vector3 nextStar = starTransforms[i+1].position;

        //Debug.DrawLine(currentStar, nextStar, Color.white, drawingTime);
    }
}
