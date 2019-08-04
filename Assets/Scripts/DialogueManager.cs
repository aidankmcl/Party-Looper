using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBubble;
    public SVGImage currentSpeaker;
    public Text dialogueText;

    public NPC[] npcs;
    public Queue<DialoguePrompt> prompts;

    public Animator dialogueAnimator;

    [Serializable] private class DialogueSpriteEntry
    {
        public PromptColor color;
        public Sprite dialogueSprite;
    }

    [SerializeField] private List<DialogueSpriteEntry> dialogueSprites;
    private Dictionary<PromptColor, Sprite> dialogueSpriteLookup;

    void Awake() {
        dialogueSpriteLookup = new Dictionary<PromptColor, Sprite>();
 
        foreach(DialogueSpriteEntry entry in dialogueSprites)
        {
            dialogueSpriteLookup.Add(entry.color, entry.dialogueSprite);
        }
    }

    void Start() {
        dialogueAnimator.SetBool("IsOpen", false);
        prompts = new Queue<DialoguePrompt>();
    }

    public void StartDialog(NPC[] newNpcs, DialoguePrompt[] newPrompts) {
        npcs = newNpcs;
        prompts.Clear();

        foreach (DialoguePrompt prompt in newPrompts) {
            prompts.Enqueue(prompt);
        }

        DisplayNextPrompt();
    }

    public void DisplayNextPrompt() {
        dialogueAnimator.SetBool("IsOpen", false);
        if (prompts.Count == 0) {
            EndDialogue();
            return;
        }

        DialoguePrompt prompt = prompts.Dequeue();
        NPC npc = npcs[prompt.NPC];
        dialogueBubble.GetComponent<Image>().sprite = dialogueSpriteLookup[npc.promptColor];
        currentSpeaker.sprite = npc.headImage.sprite;
        dialogueText.text = prompt.text;
        dialogueAnimator.SetBool("IsOpen", true);

    }

    public void EndDialogue() {
        prompts.Clear();
        dialogueAnimator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextPrompt();
        }
    }
}
