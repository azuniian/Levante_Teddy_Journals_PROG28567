using UnityEngine;

public class mathFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 position = transform.position; 
        
        //find magnitude the long way
        //float magnitude = Mathf.Sqrt(position.x * position.x + position.y * position.y);

        //get magnitude short way
        float magnitude = GetMagnitude(position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetMagnitude(Vector2 position)
    {
        return Mathf.Sqrt(position.x * position.x + position.y * position.y);
    }

    public static void DrawSquare(Vector2 position, float sideSize, Color color, float duration)
    {
        Vector2 topLeft = new Vector2(position.x, position.y);
        Vector2 topRight = new Vector2(position.x + sideSize, position.y);
        Vector2 botLeft = new Vector2(position.x, position.y - sideSize);
        Vector2 botRight = new Vector2(position.x + sideSize, position.y - sideSize);

        //re-used spawn square code from square spawner
        Debug.DrawLine(topLeft, botLeft, Color.white, 5);
        Debug.DrawLine(topLeft, topRight, Color.white, 5);
        Debug.DrawLine(topRight, botRight, Color.white, 5);
        Debug.DrawLine(botRight, botLeft, Color.white, 5);

        //codeshare in-class version
        /*Vector2 topLeftPoint = position + Vector2.up * size / 2f + Vector2.left * size / 2;
        Vector2 topRightPoint = position + Vector2.up * size / 2f + Vector2.right * size / 2;
        Vector2 bottomLeftPoint = position + Vector2.down * size / 2f + Vector2.left * size / 2;
        Vector2 bottomRightPoint = position + Vector2.down * size / 2f + Vector2.right * size / 2;

				
        Debug.DrawLine(topLeftPoint, topRightPoint, color, duration);
        Debug.DrawLine(topRightPoint, bottomRightPoint, color, duration);
        Debug.DrawLine(bottomRightPoint, bottomLeftPoint, color, duration);
        Debug.DrawLine(bottomLeftPoint, topLeftPoint, color, duration);*/

    }
}
