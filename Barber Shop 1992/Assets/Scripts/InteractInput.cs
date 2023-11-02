using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInput : MonoBehaviour
{
    //Checks if interact (e) was pressed
    private bool interactPressed = false;

    //Instance of this class
    private static InteractInput instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static InteractInput GetInstance()
    {
        return instance;
    }

    //Interact button has been pressed
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    //E has been pressed now reset it
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }
}
