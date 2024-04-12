using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour
{
    public Animator animator;


    void Update()
    {
        // Check if any movement key is pressed
        bool isMoving = Input.GetAxis("JoystickHorizontal") != 0 || Input.GetAxis("JoystickVertical") != 0;
        ;

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
