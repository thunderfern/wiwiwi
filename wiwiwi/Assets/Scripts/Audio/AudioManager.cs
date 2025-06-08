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
    private float musicTarget;
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
        if (Input.GetKeyDown(KeyCode.E)) PlaySound(AudioType.Click);
        if (Input.GetKeyDown(KeyCode.B)) PlaySound(AudioType.Click);

        if (musicSource.volume != musicTarget)
        {
            if (musicSource.volume < musicTarget)
            {
                musicSource.volume += Mathf.Min(Time.deltaTime / 10f, musicTarget - musicSource.volume);
            }
            else musicSource.volume -= Mathf.Min(Time.deltaTime / 10f, musicSource.volume - musicTarget);
        }
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

    void playFirst(AudioType audio, float volume)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!SFXSources[i].isPlaying)
            {
                SFXSources[i].volume = volume;
                SFXSources[i].clip = audioList[(int)audio];
                SFXSources[i].Play();
                return;
            }
        }
    }

    public void StopSound(AudioType audio) {
        if (audio == AudioType.Null) return;
        for (int i = 0; i < 4; i++)
        {
            if (SFXSources[i].clip == audioList[(int)audio])
            {
                SFXSources[i].Stop();
            }
        }
    }

    public void PlaySound(AudioType audio, float volume = 1)
    {
        if (audio == AudioType.Null) return;
        if (!checkPlaying(audio))
        {
            playFirst(audio, volume);
        }
    }

    public void PlayBackground(BackgroundMusic audio, float volume = 0.5f)
    {
        if (!musicSource.isPlaying)
        {
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
    }

    public void BackgroundVolume(float volume)
    {
        musicTarget = volume;
    }
}
