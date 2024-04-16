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

    /*void OnCollisionEnter(Collider collision) {
        if(collision.gameObject.tag == "Player") {
            text.SetActive(true);
        }
    }

    void OnCollisionExit(Collider collision) {
        if(collision.gameObject.tag == "Player") {
            text.SetActive(false);
        }
    }*/
}
