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
    private List<AudioSource> SFXSources;

    void Start()
    {
        SFXSources = new List<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        SFXSources.Add(transform.GetChild(1).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(2).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(3).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(4).GetComponent<AudioSource>());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlaySound(AudioType.Click);
    }


    bool checkPlaying(AudioType audio)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!SFXSources[i].isPlaying) continue;
            if (SFXSources[i].clip == audioList[(int)audio]) return true;
        }
        return false;
    }

    void playFirst(AudioType audio)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!SFXSources[i].isPlaying)
            {
                SFXSources[i].clip = audioList[(int)audio];
                SFXSources[i].Play();
                return;
            }
        }
    }

    public void PlaySound(AudioType audio, float volume = 1)
    {
        if (!checkPlaying(audio))
        {
            playFirst(audio);
        }
    }

    public void PlayBackground(BackgroundMusic audio, float volume = 0.5f)
    {
        if (!musicSource.isPlaying)
        {
            Debug.Log("hello?\n");
            musicSource.clip = backgroundList[(int)audio];

            musicSource.Play();
        }
        else
        {
            if (musicSource.clip != backgroundList[(int)audio])
            {
                musicSource.clip = backgroundList[(int)audio];
                musicSource.Play();
            }
        }
        if (musicSource.isPlaying)
        {
            if (musicSource.volume < 1)
            {
                musicSource.volume += Mathf.Min(Time.deltaTime / 10f, 1.0f - musicSource.volume);
            }
        }
    }

    public void BackgroundVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
