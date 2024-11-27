using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class carMovement : MonoBehaviour
{
    public float speed = 3f;
    public GameObject car;
    private Rigidbody rb;
    private float _currentVelocity;
    public float smoothTime = 0.25f;
    private Quaternion lastRotation;


    private void Start()
    {
        rb = car.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("JoystickHorizontal");
        float vertical = Input.GetAxis("JoystickVertical");


        Vector3 movementDirection = new Vector3(vertical * speed, 0, -horizontal * speed);
        transform.Translate(movementDirection, Space.World);

        if (movementDirection.magnitude > 0) // If moving
        {
            var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            lastRotation = transform.rotation;
        }
        else // If not moving, apply the last rotation
        {
            transform.rotation = lastRotation;
        }


        car.transform.position = transform.position;
    }
}