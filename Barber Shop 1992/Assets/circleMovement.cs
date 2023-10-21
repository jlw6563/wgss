using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using UnityEngine;

public class circleMovement : MonoBehaviour
{

    float speed = 5f;

    float timer = 0;
    Vector3 direction = Vector3.left;


    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {    
        transform.position += direction * speed * Time.deltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Left End")
        {
            direction = Vector3.right;
        }
        if (collision.gameObject.name == "Right End")
        {
            direction = Vector3.left;
        }
    }
}
