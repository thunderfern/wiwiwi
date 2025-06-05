using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Singleton

    private static AudioManager _instance;

    private AudioManager()
    {
        _instance = this;

    }

    public static AudioManager instance()
    {
        if (_instance == null)
        {
            AudioManager instance = new AudioManager();
            _instance = instance;
        }
        return _instance;
    }

    public AudioClip[] audioList;
    public AudioClip[] backgroundList;
    public List<float> backgroundLength;
    public List<float> backgroundCurrent;
    private AudioSource musicSource;
    private AudioSource SFXSource;

    void Start()
    {
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        SFXSource = transform.GetChild(1).GetComponent<AudioSource>();
    }


    public void PlaySound(AudioType audio, float volume = 1)
    {
        //if (!audioList[(int)audio].isPlaying) audioSource.PlayOneShot(audioList[(int)audio], volume);
    }
    
    public void PlayBackground(BackgroundMusic audio, float volume = 1)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = backgroundList[(int)audio];
            musicSource.Play();
        }
    }
}
