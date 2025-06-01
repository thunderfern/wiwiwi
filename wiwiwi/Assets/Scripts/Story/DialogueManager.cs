using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    // Singleton

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

    // Fields
    public TMP_Text dialogueText;
    public TMP_Text characterText;
    public GameObject dialogueObject;
    public GameObject characterPortraitObject;
    public SpriteRenderer characterPortraitRenderer;
    public List<DialogueScreen> dialogueStream;
    public float curTextTimer;

    public List<Sprite> playerSprites;

    private List<List<Sprite>> characterSprites;

    void Start()
    {
        characterSprites = new List<List<Sprite>>();
        characterSprites.Add(playerSprites);
        curTextTimer = 0;
    }

    void Update()
    {
        if (World.instance().curstate == GameState.Dialogue) {
            if (dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters < dialogueStream[0].dialogueText.Length) {
                curTextTimer += Time.deltaTime;
                dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters = (int)(curTextTimer * 20);
                if (Input.GetKeyDown(KeyCode.E)) dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters = dialogueStream[0].dialogueText.Length;
            }
            else if (Input.GetKeyDown(KeyCode.E)) displayNext();
        }
    }

    public void updateDialogue(List<DialogueScreen> dialogueStream)
    {
        dialogueObject.SetActive(true);
        this.dialogueStream = dialogueStream;
        this.display();
    }

    public void display()
    {
        if (dialogueStream.Count == 0) return;

        // text display
        characterText.GetComponent<TMP_Text>().text = dialogueStream[0].characterString;
        dialogueText.GetComponent<TMP_Text>().text = dialogueStream[0].dialogueText;
        dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters = 0;
        curTextTimer = 0;

        // character portrait
        if (dialogueStream[0].character != Character.Narrator && dialogueStream[0].character != Character.Unknown)
        {
            characterPortraitObject.SetActive(true);
            characterPortraitRenderer.sprite = characterSprites[(int)dialogueStream[0].character][(int)dialogueStream[0].emotion];
        }
        else characterPortraitObject.SetActive(false);
    }

    public void displayNext() {
        dialogueStream.RemoveAt(0);
        if (dialogueStream.Count == 0) {
            World.instance().curstate = World.instance().prevstate;
            dialogueObject.SetActive(false);
            return;
        }
        display();
    }

}
