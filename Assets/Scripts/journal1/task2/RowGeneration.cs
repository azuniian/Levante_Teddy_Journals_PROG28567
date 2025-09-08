using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    
    public TMPro.TMP_InputField inputField;
    //public TMPro.TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextChecker()
    {
        //Debug.Log(inputField.text);
        if (int.TryParse(inputField.text, out int value) && value >= 0)
        {
            for (int i = 0; i < value, i++) {
                //create a new point that changes position for each iteration of the for loop
                Vector2 newPoint = new Vector2(i, 0);

                //re-used code from square spawner
                Vector2 topLeft = new Vector2(newPoint.x, newPoint.y);
                Vector2 topRight = new Vector2(newPoint.x + 1, newPoint.y);
                Vector2 botLeft = new Vector2(newPoint.x, newPoint.y - 1);
                Vector2 botRight = new Vector2(newPoint.x + 1, newPoint.y - 1);

                //re-used spawn square code from square spawner
                Debug.DrawLine(topLeft, botLeft, Color.white, 5);
                Debug.DrawLine(topLeft, topRight, Color.white, 5);
                Debug.DrawLine(topRight, botRight, Color.white, 5);
                Debug.DrawLine(botRight, botLeft, Color.white, 5);
            }
            //Debug.Log(value);
        }

        else
        {
            Debug.Log("not a valid number/entry");
        }
    }
}
