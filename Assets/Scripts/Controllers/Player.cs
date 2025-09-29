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

    public TMPro.TMP_InputField ratioInputField;



    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (float.TryParse(ratioInputField.text, out float value) && value >= 0 && value <= 1)
            {
                
            }
        }


    }

}
