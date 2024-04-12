using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    public float speed = 3f;
    public GameObject martti;
    public float jumpForce = 8f;
    private Rigidbody rb;
    private float _currentVelocity;
    public float smoothTime = 0.25f;


    private void Start()
    {
        rb = martti.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("JoystickHorizontal");
        float vertical = Input.GetAxis("JoystickVertical");


        Vector3 movementDirection = new Vector3(vertical * speed, 0, -horizontal * speed);
        transform.Translate(movementDirection, Space.World);

        var targetAngle = Mathf.Atan2(movementDirection.z, -movementDirection.x) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

        martti.transform.position = transform.position;


        /*if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            martti.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            martti.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            martti.transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
            martti.transform.rotation = Quaternion.Euler(0, -90f, 0);
        }**/

        //jumping
        if (Input.GetButtonDown("Jump"))  //Y-button
        {
            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}