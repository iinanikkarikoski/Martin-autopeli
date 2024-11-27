using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    /*private GameObject grabbedObject;
    private bool isGrabbing = false;

    void Update()
    {
        // Check if Ctrl key is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (!isGrabbing)
            {
                // If not already grabbing, try to grab an object
                TryGrab();
            }
            else
            {
                // If already grabbing, release the object
                ReleaseObject();
            }
        }
    }

    void TryGrab()
    {
        // Raycast to check if there's an object in front of the character
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            // Check if the object has a Rigidbody component (to ensure it can be grabbed)
            if (hit.collider.GetComponent<Rigidbody>())
            {
                grabbedObject = hit.collider.gameObject;
                // Make the grabbed object kinematic to prevent physics from affecting it while grabbed
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                isGrabbing = true;
            }
        }
    }

    void ReleaseObject()
    {
        // Release the grabbed object
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
            isGrabbing = false;
        }
    }*/
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    public bool hasItem; // a bool to see if you have an item in your hand
    private float triggerDisplacement;
                  // Start is called before the first frame update

    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true && hasItem == false) // if you enter thecollider of the objecct
        {
            if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) {
                if(triggerDisplacement > 0.5f){
                    ObjectIwantToPickUp.GetComponent<BoxCollider>().enabled = false;

                    ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                    ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                    ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                    hasItem = true;
                }
            }
        }
       
        if(hasItem == true){
            
            if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) {
                if(triggerDisplacement < 0.5){
          
                    ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
                    ObjectIwantToPickUp.GetComponent<BoxCollider>().enabled = true;
                    ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
            
                
                    hasItem = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (!hasItem){
        if (other.gameObject.tag == "grabbable") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }}
    }
    private void OnTriggerExit(Collider other)
    { 
        canpickup = false; //when you leave the collider set the canpickup bool to false
        if (hasItem){
        ObjectIwantToPickUp.transform.parent = null;
        ObjectIwantToPickUp.GetComponent<BoxCollider>().enabled = true;
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false;
            hasItem = false;
        }

    }
}
