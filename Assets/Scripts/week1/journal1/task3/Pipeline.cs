using System.Collections;
using System.Collections.Generic; //referenced Unity API scripting (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections#BKMK_KindsOfCollections) to figure out how to get normal Lists to work with Unity 6000
using System.Net.NetworkInformation;
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    //public Vector2 mousePosition;
    //public Transform mousePos;
    
    public List<Vector2> mousePositions = new List<Vector2>();
    public int lastPos = 0; //array int
    float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition; //get mouse position at any given frame
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(mousePos); //get mouse position into world space
        //Vector2 origin = new Vector2(0, 0);

        if (Input.GetMouseButtonDown(0)) //on mouse click, get the current mouse position into the list
        {
            mousePositions.Add(currentPos); //add the current mouse position to the list
            Debug.Log(mousePositions[lastPos]); 
        }

        if (Input.GetMouseButton(0)) //checks to see if mouse is still being held
        {
            if (time >= 0.1) //check for timing and reset the time value if its been more than 0.1 seconds so that a new line can be drawn
            {
                mousePositions.Add(currentPos); //add the new mouse position to the list
                Debug.DrawLine(currentPos, mousePositions[lastPos], Color.white, Mathf.Infinity); //draw a line between the current position (currentPos) and
                //the second newest mouse position in the list
                lastPos++; //add to the lastPos integer value so next time the current position will become the 'last' position
                time = 0; //reset time
            }
        }

        if (Input.GetMouseButtonUp(0)) //calculates magnitude of whole line, then clears the list so a new line can be drawn again
        {
            mousePositions.Clear();
        }

        time += Time.deltaTime;

    }

        
}
