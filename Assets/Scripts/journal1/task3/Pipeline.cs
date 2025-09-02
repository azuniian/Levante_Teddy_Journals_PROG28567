using System.Collections;
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public Vector2 mousePosition;
    public Transform mousePos;
    public Vector2[] mousePositions;
    Vector2 origin = new Vector2(0, 0); //very start

    public int currentPos = 1; //array int

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePositions = new Vector2[];
        mousePositions[currentPos] = origin;
        currentPos++;
    }

    // Update is called once per frame
    void Update()
    {
        //variables 
        
        Vector2 start = new Vector2(); //previous end position for line drawing
        Vector2 end = new Vector2(); //current end position for line drawing (mousePos)
        //Vector2 newLine = new Vector2(); 

        mousePosition = Input.mousePosition; //thank you Kano for helping me remember how to get a mouse position 
        
        //get mouse position
        if(Input.GetMouseButtonDown(0) == true)
        {
            mousePos.position = mousePosition;
            Debug.Log(mousePos.position);

        }

        if (Input.GetMouseButton(0) == true)
        {
            currentPos++;

            end = mousePos.position;
            mousePositions[currentPos] = end;
            start = mousePositions[currentPos - 1];

            Debug.Log(currentPos);
        }
        
    }
}
