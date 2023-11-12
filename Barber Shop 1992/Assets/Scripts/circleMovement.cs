using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class circleMovement : MonoBehaviour
{
    // === Created by Jake ===


    //Speed of the circle
    float speed = 10f;

    //The direction the circle is moving
    Vector3 direction = Vector3.left;

    private void Start()
    {
        //Just starts the circle in the center of the screen on start
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {   
        //Moves the ball by the direction multiply by speed and delta time
        transform.position += direction * speed * Time.deltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //The collision work solely with the 2 bounds I created and named left end and right end


        //When there is a collisoin and the object is named left end
        if(collision.gameObject.name == "Left End")
        {
            //switches the direciton and the rotation
            direction = Vector3.right;
            transform.rotation = new Quaternion(0, 0, 180,0);
        }

        //For when the collided object is named right end
        if (collision.gameObject.name == "Right End")
        {
            //Switches the direction and rotation
            direction = Vector3.left;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
