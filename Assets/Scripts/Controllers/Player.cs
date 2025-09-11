using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMPro.TMP_InputField ratioInputField;

    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //journal task 1B variables
    public int inNumberOfBombs;
    public float inBombSpacing;

    //public Transform playerTransform;

    void Update()
    {
        //movement/normalize exercise
        float speed = 0.5f;

        Vector2 targetPosition = enemyTransform.position;
        Vector2 startPosition = transform.position;
        //to find direction, remove the start FROM the target (seems backwards)
        Vector2 directionToMove = targetPosition - startPosition;

        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.position += (Vector3)directionToMove.normalized * speed; //normalized to not change the amount moved depending on distance between player and enemy
        }


        //bomb example exercise
        //check for key press
        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 offset = new Vector3(0, 1, 0); //offset from the player
            SpawnBombAtOffset(offset);
        }

        //bomb trail journal task 1B
        //check for key press
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(transform.position);
            SpawnBombTrail(inBombSpacing, inNumberOfBombs);
        }


        //warp player method call
        if (Input.GetKeyDown(KeyCode.W))
        { 
            if (float.TryParse(ratioInputField.text, out float value) && value >= 0 && value <= 1)
            {
                WarpPlayer(enemyTransform, value);
            } 
        }


        /*//warp drive exercise in class
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 distanceToWarp = new Vector2(3, 0); 
            
            //find distance between enemy ship and player
            //multiply by the inputfield value (0 to 1) to determine how much of distance has to be elapsed
            //method call to do the movement

            WarpOver(distanceToWarp, speed, directionToMove);
        }*/
    }

    //bomb example exercise method
    //method to spawn a bomb at the player's location plus the offset
    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab, (transform.position + inOffset), Quaternion.identity); //https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Object.Instantiate.html instantiate parameters taken from here
    }

    //bomb trail journal task 1B method
    //method to spawn bomb trail after bomb location with inputted spacing and number of bomb values
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for(int i = 1; i <= inNumberOfBombs; i++)
        {
            Vector3 bombSpawnPosOffset = new Vector3(transform.position.x, i * inBombSpacing, transform.position.z);
            //Debug.Log(transform.position - bombSpawnPosOffset);
            Instantiate(bombPrefab, (transform.position - bombSpawnPosOffset), Quaternion.identity);
        }
    }


    //warp drive task
    public void WarpPlayer(Transform target, float ratio)
    {
        Vector3 targetVector = target.position;
        Vector3 playerPosition = transform.position;
        Vector3 warpDirection = targetVector - playerPosition;

        transform.position += (Vector3)warpDirection * ratio;
    }



    /*//warp drive example exercise method in class
    public void WarpOver(Vector2 warpDistance, float speed, Vector2 warpDirection)
    {
        //find a warp direction to ensure it isn't just going one way
        warpDistance *= (Vector3)warpDirection.normalized; //check direction for warping
        
        //warp a set vector distance (currently 3 units in the x axis)
        transform.position += (Vector3)warpDistance * speed;
    }*/
}
