using UnityEngine;

public enum Emotion {
    Happy,
    Sad,
    Neutral
}

public class DialogueScreen
{
    public Character character;
    public Emotion emotion;
    public string dialogueText;
    // add sound

    public DialogueScreen(string character, string emotion, string dialogueText, string sound) {

        switch (character)
        {
            case "player":
                this.character = Character.Player;
                break;
            default:
                this.character = Character.MrMole;
                break;
        }

        switch (emotion)
        {
            case "happy":
                this.emotion = Emotion.Happy;
                break;
            default:
                this.emotion = Emotion.Sad;
                break;
        }

        this.dialogueText = dialogueText;

    }
}
