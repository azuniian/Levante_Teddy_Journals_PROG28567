using System.Collections;
using System.Collections.Generic; //referenced Unity API scripting (find link) to figure out how to get normal Lists to work with Unity 6000
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    //public Vector2 mousePosition;
    //public Transform mousePos;
    public List<Vector2> mousePositions = new List<Vector2>();

    public int currentPos = 1; //array int

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            mousePositions.Add(mousePos);
            Debug.Log(mousePositions[currentPos]);
            currentPos++;

            if (Input.GetMouseButton(0))
            {
                //mousePositions.Add(mousePos);
                //Debug.DrawLine(mousePositions[currentPos - 1], mousePositions[currentPos]);
                //currentPos++;
            }
        }

        

    }





























/*
    Debug.Log(currentPos);

        //variables 

        Vector2 start = new Vector2(); //previous end position for line drawing
    Vector2 end = new Vector2(); //current end position for line drawing (mousePos)
    Vector2 origin = new Vector2(0, 0); //very start

    mousePosition = Input.mousePosition; //thank you Kano for helping me remember how to get a mouse position 
        
        //get mouse position
        if(Input.GetMouseButtonDown(0) == true)
        {
            mousePos.position = mousePosition;
            Debug.Log(mousePos.position);

        }

if (Input.GetMouseButton(0) == true)
{

    //end = mousePos.position;
    //mousePositions[currentPos] = end;
    //start = mousePositions[currentPos - 1];

    //Debug.Log(currentPos);

    //currentPos++;
}*/

        
}
