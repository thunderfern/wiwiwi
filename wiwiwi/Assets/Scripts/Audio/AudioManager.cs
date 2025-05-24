using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Sound
{

}



public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    public AudioClip[] soundList;
    //public List<Sound> soundQueue;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
