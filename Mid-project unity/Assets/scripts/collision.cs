using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject text;


    void Start() 
    {
        text.SetActive(false);
    }

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "Player") {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision) {
        if(collision.gameObject.tag == "Player") {
            text.SetActive(false);
        }
    }
}
