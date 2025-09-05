using UnityEngine;

public class SquareSpawner : MonoBehaviour
{

    Vector2 squareLeftTop = new Vector2(); //top left corner position
    Vector2 squareRightTop = new Vector2(); //top right corner position
    Vector2 squareLeftBottom = new Vector2(); //bottom left corner position
    Vector2 squareRightBottom = new Vector2(); //bottom right corner position

    float sizeIncrease; //what scroll wheel will increase

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 squarePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            //get new coordinates for the top left corner
            squareLeftTop.x = squarePos.x - 2;
            squareLeftTop.y = squarePos.y + 2;

            //get new coordinates for the top right corner
            squareRightTop.x = squarePos.x + 2;
            squareRightTop.y = squarePos.y + 2;

            //get new coordinates for the bottom left corner
            squareLeftBottom.x = squarePos.x - 2;
            squareLeftBottom.y = squarePos.y - 2;

            //get new coordinates for the top left corner
            squareRightBottom.x = squarePos.x + 2;
            squareRightBottom.y = squarePos.y - 2;


            //draw square
            Debug.DrawLine(squareLeftTop, squareLeftBottom, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareLeftTop, squareRightTop, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareRightTop, squareRightBottom, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareRightBottom, squareLeftBottom, Color.white, Mathf.Infinity);
        }
        
    }
}
