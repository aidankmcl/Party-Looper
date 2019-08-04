using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlternatePrompts {
    [TextArea(3, 5)]
    public string text;
    [MinMaxRange(0, 1)]
    public RangedFloat socialScoreRange;
}

[System.Serializable]
public class DialoguePrompt
{
    public int NPC;
    [TextArea(3, 5)]
    public string text;
    public AlternatePrompts[] alternatePrompts;

    public DialogueAnswer[] answers;
}
