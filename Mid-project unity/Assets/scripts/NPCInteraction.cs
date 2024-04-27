using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject player;  // Reference to the player GameObject
    public float interactionDistance = 6f;  // Distance to trigger interaction

    private bool isPlayerNearby;
    public DialogueUI dialogueUI;
    public GameObject text;
    private enum InteractionState
    {
        None,          
        ConversationOne, 
        ConversationTwo,
        ConversationThree,
        ConversationFour  
    }

    private InteractionState currentState = InteractionState.None;

    void Start() 
    {
        text.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 40 && distance > 30)
        {
            if (currentState != InteractionState.ConversationOne)
            {
                currentState = InteractionState.ConversationOne;
                ConversationOne();  
            }
        }
        else if (distance <= 30 && distance > 10)
        {
            if (currentState != InteractionState.ConversationTwo)
            {
                currentState = InteractionState.ConversationTwo;
                ConversationTwo();
            }
        }
        else if (distance <= 10 && distance > 5)
        {
            if (currentState != InteractionState.ConversationThree)
            {
                currentState = InteractionState.ConversationThree;
                ConversationThree();
            }
        }
        else if (distance <= 5)
        {
            text.SetActive(true);
            if (currentState != InteractionState.ConversationFour)
            {
                currentState = InteractionState.ConversationFour;
                ConversationFour();
            }
        }
        else
        {
            if (currentState != InteractionState.None)
            {
                currentState = InteractionState.None;
                EndConversation();
            }
        }
    }

    void ConversationOne() 
    {
        dialogueUI.ShowDialogue("Hello! You there!");
    }
    void ConversationTwo() {

        dialogueUI.ShowDialogue("Here! The funny blue guy!");
    }
    void ConversationThree()
    {
        dialogueUI.ShowDialogue("You look like, you wanna drive!");
    }
    void ConversationFour()
    {
        dialogueUI.ShowDialogue("Yo! I'm Terho. Check out the car I made and take it to a test drive!");
    }
    void EndConversation()
    {
        dialogueUI.HideDialogue();
    }
}
