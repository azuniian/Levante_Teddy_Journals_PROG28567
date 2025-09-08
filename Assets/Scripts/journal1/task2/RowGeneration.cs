using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text text;

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
        Debug.Log(text.ToString());
    }
}
