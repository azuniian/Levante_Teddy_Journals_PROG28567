using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Transform playerTransform;

    void Update()
    {
        
        Vector3 offset = new Vector3(0, 1, 0); //offset from the player
        Vector3 playerPos = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z); //player position from the playerTransform reference in the scene

        //check for key press
        if (Input.GetKeyDown(KeyCode.B)){

            Player.SpawnBombAtOffset(offset, playerPos, bombPrefab);
        }
    }

    //method to spawn a bomb at the player's location plus the offset
    public static void SpawnBombAtOffset(Vector3 inOffset, Vector3 playerPos, GameObject bomb)
    {
        Instantiate(bomb, (playerPos + inOffset), Quaternion.identity); //https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Object.Instantiate.html instantiate parameters taken from here
    }
}
