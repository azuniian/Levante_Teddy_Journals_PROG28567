using UnityEngine;

public class Follower : MonoBehaviour
{
    public float speed;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get direction to target via vector subtraction
        Vector3 directionToTarget = target.position - transform.position;
        Vector3 changeInPosition = directionToTarget.normalized * speed * Time.deltaTime;


        //if we are not too close to the target, then we move
        if (directionToTarget.magnitude > changeInPosition.magnitude)
        {
            //move towards target
            transform.position += changeInPosition;
        }
        //else if overshoot, then hard set the position
        else
        {
            transform.position = target.position;
        }
    }
}
