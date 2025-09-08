using UnityEngine;

public class SquareSpawner : MonoBehaviour
{

    Vector2 squareLeftTop = new Vector2(); //top left corner position
    Vector2 squareRightTop = new Vector2(); //top right corner position
    Vector2 squareLeftBottom = new Vector2(); //bottom left corner position
    Vector2 squareRightBottom = new Vector2(); //bottom right corner position

    float sideSize = 1; //what scroll wheel will increase

    Color semiTrans = new Color(1, 1, 1, 0.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 squarePos = Camera.main.ScreenToWorldPoint(mousePos);

        
        //get the changing value of side size based on scroll wheel
        sideSize += Input.mouseScrollDelta.y;
        Debug.Log(sideSize);
       

        //get new coordinates for the top left corner
        squareLeftTop.x = squarePos.x - sideSize;
        squareLeftTop.y = squarePos.y + sideSize;

        //get new coordinates for the top right corner
        squareRightTop.x = squarePos.x + sideSize;
        squareRightTop.y = squarePos.y + sideSize;

        //get new coordinates for the bottom left corner
        squareLeftBottom.x = squarePos.x - sideSize;
        squareLeftBottom.y = squarePos.y - sideSize;

        //get new coordinates for the top left corner
        squareRightBottom.x = squarePos.x + sideSize;
        squareRightBottom.y = squarePos.y - sideSize;



        if (Input.GetMouseButtonDown(0))
        {
            //draw square on click
            Debug.DrawLine(squareLeftTop, squareLeftBottom, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareLeftTop, squareRightTop, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareRightTop, squareRightBottom, Color.white, Mathf.Infinity);
            Debug.DrawLine(squareRightBottom, squareLeftBottom, Color.white, Mathf.Infinity);
        }


        //draw square at mouse position
        Debug.DrawLine(squareLeftTop, squareLeftBottom, semiTrans);
        Debug.DrawLine(squareLeftTop, squareRightTop, semiTrans);
        Debug.DrawLine(squareRightTop, squareRightBottom, semiTrans);
        Debug.DrawLine(squareRightBottom, squareLeftBottom, semiTrans);


    }
}
