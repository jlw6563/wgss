using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingGameplay : MonoBehaviour
{

    private  Vector3 mousePosition;

    private List<Vector3> pointArray = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the mouse position in screen coordinates
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        foreach (Vector3 point in pointArray)
        {
            // Printing each Vector3 object
            Debug.Log(point);

            
        }
    }


    public void PlacePoint()
    {
        pointArray.Add(mousePosition);

    }

    // Checks if the mouse is down
    public bool MouseIsDown(InputAction.CallbackContext context)
    {
        return context.performed;
    }
}
