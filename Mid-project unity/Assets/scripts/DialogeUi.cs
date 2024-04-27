using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // Reference to the Text component

    public void ShowDialogue(string message)
    {
        dialogueText.gameObject.SetActive(true);  // Make the text visible
        dialogueText.text = message;  // Set the dialogue message
    }

    public void HideDialogue()
    {
        dialogueText.gameObject.SetActive(false);  // Hide the text
    }
}