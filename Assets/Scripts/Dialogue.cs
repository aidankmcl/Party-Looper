using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour {
    public NPC[] npcs;
    public DialoguePrompt[] prompts;

    private DialogueManager dialogueManager;

    void Start() {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {   
        dialogueManager.StartDialog(npcs, prompts);
    }

    private void OnTriggerExit2D(Collider2D other) {
        dialogueManager.EndDialogue();    
    }
}
