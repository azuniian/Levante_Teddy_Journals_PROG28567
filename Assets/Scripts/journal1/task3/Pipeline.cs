using System.Collections;
using System.Collections.Generic; //referenced Unity API scripting (find link) to figure out how to get normal Lists to work with Unity 6000
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
        Vector2 mousePos = Input.mousePosition;
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 origin = new Vector2(0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            mousePositions.Add(currentPos);
            Debug.Log(mousePositions[lastPos]); 
        }

        if (Input.GetMouseButton(0))
        {
            if (time >= 0.1)
            {
                mousePositions.Add(currentPos);
                Debug.DrawLine(currentPos, mousePositions[lastPos], Color.white, Mathf.Infinity); //currently drawing a line between the current point and itself...need timer to add a new point after 0.1 seconds so i can then draw line between
                lastPos++;
                time = 0;
            }
        }

        time += Time.deltaTime;

    }

        
}
