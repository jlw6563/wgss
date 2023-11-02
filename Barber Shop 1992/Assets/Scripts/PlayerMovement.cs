using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

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
    /* Commenting this out for now, can prbly just delete
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "InteractRadius")
        {
            Debug.Log("Inside");
            InteractKey.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InteractRadius")
        {
            Debug.Log("Outside");
            InteractKey.gameObject.SetActive(false);
        }
    } */
}
