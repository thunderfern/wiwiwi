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
    public List<Setup> setupStream;
    public float curTextTimer;

    public List<Sprite> playerSprites;
    public List<Sprite> moleSprites;
    public List<Sprite> platypusSprites;
    public List<Sprite> opposumSprites;

    public List<List<Sprite>> characterSprites;

    void Awake()
    {
        characterSprites = new List<List<Sprite>>();
        characterSprites.Add(playerSprites);
        characterSprites.Add(moleSprites);
        characterSprites.Add(platypusSprites);
        characterSprites.Add(opposumSprites);
        curTextTimer = 0;
    }

    void Update()
    {
        if (World.instance().curstate == GameState.Dialogue && dialogueStream.Count > 0)
        {
            if (dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters < dialogueStream[0].dialogueText.Length)
            {
                curTextTimer += Time.deltaTime;
                dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters = (int)(curTextTimer * 20);
                if (Input.GetKeyDown(KeyCode.E)) dialogueText.GetComponent<TMP_Text>().maxVisibleCharacters = dialogueStream[0].dialogueText.Length;
            }
            else if (Input.GetKeyDown(KeyCode.E)) displayNext();
        }
    }

    public void updateDialogue(List<DialogueScreen> dialogueStream, List<Setup> setupStream)
    {
        dialogueObject.SetActive(true);
        this.dialogueStream = dialogueStream;
        this.setupStream = setupStream;
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
            Debug.Log((int)dialogueStream[0].character);
            Debug.Log(characterSprites.Count);
            //Debug.Log(characterSprites[(int)dialogueStream[0].character]);
            //Debug.Log(characterSprites[(int)dialogueStream[0].character][(int)dialogueStream[0].emotion]);
            //Debug.Log(characterPortraitRenderer.sprite);
            characterPortraitRenderer.sprite = characterSprites[(int)dialogueStream[0].character][(int)dialogueStream[0].emotion];
        }
        else characterPortraitObject.SetActive(false);

        // sound
        AudioManager.instance().PlaySound(dialogueStream[0].audio);
    }

    public void displayNext() {
        AudioManager.instance().StopSound(dialogueStream[0].audio);
        dialogueStream.RemoveAt(0);
        if (dialogueStream.Count == 0) {
            for (int i = 0; i < setupStream.Count; i++)
            {
                setupStream[i].setup();
            }
            World.instance().curstate = World.instance().prevstate[0];
            World.instance().prevstate.RemoveAt(0);
            dialogueObject.SetActive(false);
            return;
        }
        display();
    }

}
