using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour
{
    public Animator animator;


    void Update()
    {
        // Check if any movement key is pressed
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (isMoving)
        {
            // Start the walk animation
            animator.SetFloat("Walk", 1f);
        }
        else
        {
            // Stop the walk animation
            animator.SetFloat("Walk", 0f);
        }
        
    }
}