using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    //keep track if player is in range
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false; //false upon awake
        visualCue.SetActive(false); //does not show upon awake
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(InteractInput.GetInstance().GetInteractPressed())
            {
                Debug.Log(inkJSON.text);
            } 
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    //Detects if Player collider enters trigger range
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") //I set Player object in unity's tag to "Player" - Owen
        {
            playerInRange=true;
        }
    }

    //Detects if Player collider exits trigger range
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
