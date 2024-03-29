using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject wall;
    public GameObject text;


    void Start() 
    {
        text.SetActive(false);
    }
    void OnTriggerEnter(Collider collision) {
        text.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            wall.SetActive(false);
            text.SetActive(false);
        }
    }

}
