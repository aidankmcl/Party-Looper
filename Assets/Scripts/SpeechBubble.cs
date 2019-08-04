using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeechBubble", menuName = "Party Looper/SpeechBubble", order = 0)]
public class SpeechBubble : ScriptableObject {
    public string text;
    public enum Color{Pink,Yellow,BabyBlue}
    public Color theme;
}
