using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuickTimeManager : MonoBehaviour
{
    // === Created By Chinmay and Jake ===
    /* This class handles collisions for the quick time event. It figures out whether the circle is in the "Good zone"
     * Gets the input from pressing space if this is done in the good zone itll move the goodzone to a new spot with a new scale
     * If space is pressed not in the good zone then everything falls apart.
     * 
     * Issues: when space is clicked after you fail again it will cause errors to occur(Maybe use a bool to fix this?) Or making some sort of reset function
     */


    //[SerializeField]
    //Transform newTransform;

    [SerializeField]
    Collider2D goodZone; //Greem zone collider

    [SerializeField]
    Collider2D circle; //scissors circle collider

    [SerializeField]
    GameObject axis; //Red axis game object

    [SerializeField]
    Rigidbody2D circleRigidBody; //Rigid body for scissors circle

    //Value to translate
    float translationVal;
    //Value to scale
    float scaleVal;
    //Whether the good zone is visible or not
    bool goodZoneActive = true;

    //Timer for invisible
    float timer;


    //         ================== For old collision system ===============
    /*
    //Min and Max
    float minGoodZone;
    float maxGoodZone;
    float minCircle;
    float maxCircle;
  

    // Start is called before the first frame update
    void Start()
    {
        
        minGoodZone = 0 - (goodZone.transform.localScale.x / 2);
        maxGoodZone = 0 + (goodZone.transform.localScale.x / 2);
        minCircle = circle.transform.position.x - (circle.transform.localScale.x / 2);
        maxCircle = circle.transform.position.x + (circle.transform.localScale.x / 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        minGoodZone = 0 - (goodZone.transform.localScale.x / 2);
        maxGoodZone = 0 + (goodZone.transform.localScale.x / 2);
        minCircle = circle.transform.position.x - (circle.transform.localScale.x / 2);
        maxCircle = circle.transform.position.x + (circle.transform.localScale.x / 2);
        
        //Debug.Log(minGoodZone);
        
    }
    */
    // ==================================================================================

    void Update()
    {
        //This makes sure collision check is only being called if the goodZone is active
        //If the good zone is active collision are checked
        if (goodZoneActive)
        {
            CollisionCheck();
        }

        //This surves the roll of counting down when the goodzone is not active
        //Otherwise subtract from the timer
        else
        {
            timer -= Time.deltaTime;
        }

        //Checks once the timer hits 0 to revert things back
        //If the timer is below 0 and goodzone active is false
        if (timer < 0 && goodZoneActive == false)
        {
            //Just sets thing back to how they should be
            //sets good zone to true and sets goodzone to active
            goodZoneActive = true;
            goodZone.gameObject.SetActive(goodZoneActive);
        }
    }

    /// <summary>
    /// Checking collision information and updating
    /// </summary>
    void CollisionCheck()
    {
        //If space is clicked within the zone
        //If the goodzon bounds cointains the max and min of the cirlce and space is pressed
        if(goodZone.bounds.Contains(circle.bounds.max) && goodZone.bounds.Contains(circle.bounds.min) && Input.GetKeyDown(KeyCode.Space)) 
        {
            //This is for changing the scale when to random range once something is clicked
            //Scale val gets set to 2 and good zone local scale gets set to +.5 and -.5 of the scaleval
            scaleVal = 2f;
            goodZone.gameObject.transform.localScale = new Vector3(Random.Range(scaleVal -.5f , scaleVal + .5f), goodZone.transform.localScale.y);

            //This is for moving a random range within the axis gameobject 
            //Tranlationval is half the axis scale x minus goodzone scale x divideed in half
            //Then translation gets set to a range of negative translation val to positive translation val
            translationVal = axis.transform.localScale.x / 2 - goodZone.transform.localScale.x / 2;
            goodZone.gameObject.transform.position =  new Vector3 (Random.Range(-translationVal, translationVal),goodZone.gameObject.transform.position.y);

            
            //This is for setting the goodzone to be inactive
            //Good zone active is false
            //Timer is 1.5
            // Goodzone active is set to good zone active boolean variable
            goodZoneActive =false;
            timer = 1.5f;
            goodZone.gameObject.SetActive(goodZoneActive);


        //This is for if you click space outside of the zone
        //If space is clicked and the other stuff is not true
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            // === Drops everything off the screen this is a lose thing ===

            //Creates rigid body for good zone and axis
            //Made this so they drop off the screen and also so I can change data about the rigidbodies
            Rigidbody2D goodzonerigidbody2D = goodZone.gameObject.AddComponent<Rigidbody2D>();
            Rigidbody2D axisRigidBody = axis.AddComponent<Rigidbody2D>();

            // Sets angularVelocity of axis and of good zone
            //It creates a spinning effect just slightly for dropping
            axisRigidBody.angularVelocity = 7f;
            goodzonerigidbody2D.angularVelocity = 20f;

            //This makes scissors fall fast off screen with a scale of 4 set to the gravity
            //Makes the axis and good zone fall slower with .7 set to scale of gravity
            circleRigidBody.gravityScale = 4f;
            goodzonerigidbody2D.gravityScale = .7f;
            axisRigidBody.gravityScale = .7f;

            //Velocity is add with some in a direction left or right and up
            //this creates a cool jumping effect to the axis and goodzone
            axisRigidBody.velocity += new Vector2(2, 3);
            goodzonerigidbody2D.velocity += new Vector2(-2, 3);

            //Sets goodzone and circle to be triggers on there colliders so there arent werid collision
            goodZone.isTrigger = true;
            circle.isTrigger = true;
        }



        // =========== Also Old Collision system ==============
        /* 
        if(minGoodZone <= minCircle && maxGoodZone >= maxCircle && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jake");
            goodZone.transform.localScale = new Vector3(Random.Range(0.4f, 2f),goodZone.transform.localScale.y, 1f);
            //goodZone.transform.position = new Vector3(Random.Range(-1.3f, 1.3f), 0f, 1f);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ignacio");
        }
        */
        // =========================================================================
    }
}
