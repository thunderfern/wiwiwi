using UnityEngine;

public class DialogueScreen {
    public Character character;
    public Emotion emotion;
    public string dialogueText;
    public string characterString;

    // add sound

    public DialogueScreen(string character, string emotion, string sound, string dialogueText)
    {
        this.character = Mapper.instance().characterMap[character];
        this.emotion = Mapper.instance().emotionMap[emotion];
        this.dialogueText = dialogueText;
        this.characterString = character;
    }
}
