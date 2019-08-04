using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueAnswer
{
    [TextArea(3, 5)]
    public string answer;

    [Range(0, 1)]
    public float socialScore;
}
