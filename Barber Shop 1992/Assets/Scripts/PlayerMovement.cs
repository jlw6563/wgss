using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    //We should try normalizing movement to make sure player speed is the same when 2 keys are pressed

    // Update is called once per frame
    void Update()
    {
        //Will move the player to left multiplyed by speed and delta time
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left.normalized * speed * Time.deltaTime;
        }
        //For right movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right.normalized * speed * Time.deltaTime;
        }
        //For up movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up.normalized * speed * Time.deltaTime;

        }
        //For down movement
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down.normalized * speed * Time.deltaTime;
        }
    }
}
