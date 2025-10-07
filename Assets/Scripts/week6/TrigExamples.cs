using UnityEngine;

public class TrigExamples : MonoBehaviour
{

    public float currentAngle = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angleInRad = currentAngle * Mathf.Deg2Rad;
            Vector3 convertedVector = new Vector2(Mathf.Cos(angleInRad), Mathf.Sin(angleInRad));
            Debug.DrawLine(transform.position, transform.position + convertedVector, Color.white, 3f);

            float reconvertedAngle = Mathf.Atan2(convertedVector.y, convertedVector.x);
            //Debug.Log(reconvertedAngle * Mathf.Rad2Deg);
        }
    }
}
