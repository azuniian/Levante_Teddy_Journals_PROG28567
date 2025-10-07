using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float redRadians = redAngle * Mathf.Deg2Rad;
        Vector2 redVector = new Vector2(Mathf.Cos(redRadians), Mathf.Sin(redRadians));
        redVector = redVector.normalized;

        float blueRadians = blueAngle * Mathf.Deg2Rad;
        Vector2 blueVector = new Vector2(Mathf.Cos(blueRadians), Mathf.Sin(blueRadians));
        blueVector = blueVector.normalized;

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float redDotBlue = (redVector.x * blueVector.x) + (redVector.y * blueVector.y);
            Debug.Log(redDotBlue * Mathf.Rad2Deg);
        }

    }
}
