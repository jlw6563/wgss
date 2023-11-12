using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuickTimeManager : MonoBehaviour
{
    //[SerializeField]
    //Transform newTransform;

    [SerializeField]
    Collider2D goodZone;

    [SerializeField]
    Collider2D circle;

    [SerializeField]
    GameObject axis;

    float translationVal;

    /*
    //Min and Max
    float minGoodZone;
    float maxGoodZone;
    float minCircle;
    float maxCircle;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        minGoodZone = 0 - (goodZone.transform.localScale.x / 2);
        maxGoodZone = 0 + (goodZone.transform.localScale.x / 2);
        minCircle = circle.transform.position.x - (circle.transform.localScale.x / 2);
        maxCircle = circle.transform.position.x + (circle.transform.localScale.x / 2);
        */

    }

    // Update is called once per frame
    void Update()
    {
        /*
        minGoodZone = 0 - (goodZone.transform.localScale.x / 2);
        maxGoodZone = 0 + (goodZone.transform.localScale.x / 2);
        minCircle = circle.transform.position.x - (circle.transform.localScale.x / 2);
        maxCircle = circle.transform.position.x + (circle.transform.localScale.x / 2);
        */
        //Debug.Log(minGoodZone);

        CollisionCheck();
    }


    void CollisionCheck()
    {
        
        if(goodZone.bounds.Contains(circle.bounds.max) && goodZone.bounds.Contains(circle.bounds.min) && Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Collsioj");

            translationVal = axis.transform.localScale.x / 2 - goodZone.transform.localScale.x / 2;
            goodZone.gameObject.transform.position =  new Vector3 (Random.Range(-translationVal, translationVal),goodZone.gameObject.transform.position.y);
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Miss");
        }
        
        /*
        if(minGoodZone <= minCircle && maxGoodZone >= maxCircle && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jake's sexy face");
            goodZone.transform.localScale = new Vector3(Random.Range(0.4f, 2f),goodZone.transform.localScale.y, 1f);
            //goodZone.transform.position = new Vector3(Random.Range(-1.3f, 1.3f), 0f, 1f);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ignacio dirty dog eater");
        }
        */
    }

}
