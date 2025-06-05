using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonMain : MonoBehaviour
{

    private ClickMain clicker;
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clicker = new ClickMain(obj);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicker.hover() && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
