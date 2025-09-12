using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //journal task 1B variables
    public int inNumberOfBombs;
    public float inBombSpacing;

    //journal task 2 variables
    public float inDistance;

    //journal task 3 variables
    public TMPro.TMP_InputField ratioInputField;
    
    //journal task 4 variables
    public float inMaxRange;



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



        //corner bomb spawn journal task 2
        //spawn bomb on corner method call
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner(inDistance);
        }



        //warp player method call
        if (Input.GetKeyDown(KeyCode.W))
        { 
            if (float.TryParse(ratioInputField.text, out float value) && value >= 0 && value <= 1)
            {
                Debug.Log(enemyTransform.position);
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



        //radar method call
        if (Input.GetKeyDown(KeyCode.R))
        {
            DetectAsteroids(inMaxRange, asteroidTransforms);
        }
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
            Vector3 bombSpawnPosOffset = new Vector3(0, i * inBombSpacing, transform.position.z);
            //Debug.Log(transform.position - bombSpawnPosOffset);
            Instantiate(bombPrefab, (transform.position - bombSpawnPosOffset), Quaternion.identity);
        }
    }


    
    //bomb spawn in corner journal task 2 method
    //method to choose a random corner, change the offset based on which corner is chosen, and then spawn a bomb at the player's location times the distance float away from the player in a corner using an offset value
    public void SpawnBombOnRandomCorner(float inDistance)
    {
        //Debug.Log(inDistance);
        Vector3 bombSpawnCornerOffset = new Vector3();
        
        //determine which corner is being chosen using Random.Range() function
        int whichCorner = Random.Range(1, 5); //used https://docs.unity3d.com/ScriptReference/Random.Range.html to check on the int version of the Range function, since usually it is done with floats and couldn't remember if the inclusivity of parameters were the same with the int version
        //change the corner offset based on what value is chosen
        if (whichCorner == 1) //top left corner
        {
            bombSpawnCornerOffset = (Vector3.up + Vector3.left) * inDistance;
            Debug.Log("spawning at top left corner");
        }

        else if (whichCorner == 2) //top right corner
        {
            bombSpawnCornerOffset = (Vector3.up + Vector3.right) * inDistance;
            Debug.Log("spawning at top right corner");
        }

        else if(whichCorner == 3) //bottom left corner
        {
            bombSpawnCornerOffset = (Vector3.down + Vector3.left) * inDistance;
            Debug.Log("spawning at bottom left corner");
        }

        else if(whichCorner==4) //bottom right corner
        {
            bombSpawnCornerOffset = (Vector3.down + Vector3.right) * inDistance;
            Debug.Log("spawning at bottom right corner");
        }
        //Debug.Log(whichCorner);

        //spawn corner bomb
        Instantiate(bombPrefab, (transform.position + bombSpawnCornerOffset), Quaternion.identity);
    }



    //journal 2 warp drive task (task 3) method
    //method to warp player to enemy position
    public void WarpPlayer(Transform target, float ratio)
    {
        Debug.Log(target.position);
        Vector3 targetVector = target.position;
        Vector3 playerPosition = transform.position;
        Vector3 warpDirection = targetVector - playerPosition;

        transform.position += (Vector3)warpDirection * ratio;
    }



    //journal 2 radar task (task 4/5) method
    //method to activate a radar which draws lines from the player in the direction of any asteroids which fall 'in range' of the player
    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        for (int i = 0; i < inAsteroids.Count; i++) //checks each instance of an asteroid in the list by going through each indexed value
        {
            //find distance between the current asteroid being checked and the player
            float distanceBetween = Vector3.Distance(transform.position, inAsteroids[i].position); //used https://docs.unity3d.com/ScriptReference/Vector3.Distance.html to figure out the distance function syntax

            if (distanceBetween <= inMaxRange) //check for if it is in range
            {
                ////get direction towards the asteroid
                //Vector3 lineDirection = (inAsteroids[i].position - transform.position).normalized;

                ////get the coordinates of the line (2.5 length)
                //Vector3 lineBetween = lineDirection.normalized * 2.5f;

                //draw line between position and the line end point
                Debug.DrawLine(transform.position, inAsteroids[i].position, Color.green, 5);
            }
            //Debug.Log(inAsteroids[i].position);
        }
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
