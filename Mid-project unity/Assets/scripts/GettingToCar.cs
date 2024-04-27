using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingToCar : MonoBehaviour
{

    public string attachButton = "Fire2"; 
    public GameObject car; 
    private bool isAttached = false;
    private Transform carTransform;
    public Transform playerTransform;
    public movement playerMovementScript;
    public Driving carMovementScript;
    public WalkAnim walkAnim;
    public Animator carAnim;
    public Camera mainCamera;
    public Vector3 cameraCarOffset = new Vector3(0f, 2f, -5f);
    public Vector3 cameraPlayerOffset = new Vector3(0f, 2f, -5f);
    
    void Start()
    {
        carTransform = car.transform;
        carMovementScript.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(attachButton) && !isAttached)
        {
            AttachToCar();
        }
        /**else if (Input.GetButtonDown(attachButton) && isAttached)
        {
            DetachFromCar();
        }**/
    }

    private void AttachToCar()
    {
        Vector3 offsetPosition = new Vector3(0f, 0f, 0f);

        // Attach player to the car
        transform.SetParent(carTransform, true);
        transform.localPosition = offsetPosition;
        transform.localRotation = Quaternion.identity; // Reset rotation to zero
        transform.Rotate(carTransform.localRotation.eulerAngles);
        isAttached = true;

         // Disable player movement script
        playerMovementScript.enabled = false;
        walkAnim.animator.enabled = false;

        // Enable car movement script
        carMovementScript.enabled = true;
        carAnim.enabled = false;

        mainCamera.transform.SetParent(carTransform, false);
        mainCamera.transform.localPosition = cameraCarOffset;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    /**private void DetachFromCar()
    {
        // Detach player from the car
        transform.SetParent(null, true);
        Vector3 detachOffset = new Vector3(1f, 0f, 0f); // Example detach offset position (adjust as needed)
        Vector3 detachPosition = carTransform.position + detachOffset; // Calculate detach position

        // Set the player's position to the detach position
        transform.position = detachPosition;

        isAttached = false;

        // Enable player movement script
        playerMovementScript.enabled = true;
        walkAnim.animator.enabled = true;

        // Disable car movement script
        carMovementScript.enabled = false;
        //carAnim.enabled = true;

        // Re-parent the camera back to the player with specified offset
        mainCamera.transform.SetParent(playerTransform, false);
        mainCamera.transform.localPosition = new Vector3(0f, 1.5f, -2f); 
        mainCamera.transform.localRotation = Quaternion.identity;

        mainCamera.transform.LookAt(playerTransform.position + new Vector3(0f, 2f, -3f)); 
    }*/
}
