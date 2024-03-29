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

    private void Start()
    {
        rb = martti.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
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
        }
        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}