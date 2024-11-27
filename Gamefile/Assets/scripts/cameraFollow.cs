using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followPoint;

    // Offset of the camera relative to the followPoint
    public Vector3 offset = new Vector3(0, 5, -10);

    // Speed of the camera's movement for smoothing
    public float rotationSpeed = 5f;
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        // Calculate the desired position with offset
        Vector3 desiredPosition = followPoint.position + followPoint.TransformDirection(offset);

        // Smoothly interpolate towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Calculate the desired rotation to match the followPoint's rotation
        Quaternion desiredRotation = Quaternion.LookRotation(followPoint.position - transform.position);

        // Smoothly interpolate towards the desired rotation
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

        // Update the camera's rotation
        transform.rotation = smoothedRotation;
    }
}
