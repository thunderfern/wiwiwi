using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    private static DialogueManager _instance;

    private DialogueManager() {
        _instance = this;
    }

    public static DialogueManager instance() {
        if (_instance == null) {
            DialogueManager instance = new DialogueManager();
            _instance = instance;
        }
        return _instance;
    }

    public TMP_Text dialogueText;
    public List<DialogueScreen> dialogueStream;

    public DialogueManager(TMP_Text text) {
        this.dialogueText = text;
    }

    public void updateDialogue(List<DialogueScreen> dialogueStream) {
        this.dialogueStream = dialogueStream;
        this.display();
    }

    void Update() {
        if (World.instance().curstate == GameState.Dialogue) {
            if (Input.GetKeyDown(KeyCode.E)) displayNext();
        }
    }

    public void display()
    {
        dialogueText.GetComponent<TMP_Text>().text = dialogueStream[0].dialogueText;
    }

    public void displayNext()
    {
        dialogueStream.RemoveAt(0);
        if (dialogueStream.Count == 0)
        {
            World.instance().curstate = GameState.Playing;
            return;
        }
        display();
        
    }

}
