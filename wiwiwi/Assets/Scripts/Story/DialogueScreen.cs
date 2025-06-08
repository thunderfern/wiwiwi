using UnityEngine;
using System;

public class DialogueScreen {
    public Character character;
    public Emotion emotion;
    public string dialogueText;
    public string characterString;
    public AudioType audio;

    // add sound

    public DialogueScreen(string character, string emotion, string sound, string dialogueText)
    {
        this.character = Mapper.instance().characterMap[character];
        this.emotion = (Emotion)Enum.Parse(typeof(Emotion), emotion);
        this.dialogueText = dialogueText;
        this.characterString = character;
        this.audio = (AudioType)Enum.Parse(typeof(AudioType), sound);
    }
}
