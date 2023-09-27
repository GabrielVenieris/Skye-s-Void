using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.picth;
            s.source.loop = s.loop;
        }
    }

    void Start ()
    {
        Play("GameMusic");
    }

    public void Play (String name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
        S.source.Play();
    }


}
