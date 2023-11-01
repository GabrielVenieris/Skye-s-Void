using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

/*
Singleton
Define a organização do áudio do jogo: Ainda incompleto(em funcionamento)
func Play = Basta chamar onde quiser e passar o nome do áudio como parametro(nome que é dado ao colocar ele dentro do script "Sound"), pelo inspector.
*/

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
        if (SceneManager.GetActiveScene().name != "StartMenuScene" ){
            PlayMusic("GameMusic");
        }
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenuScene" ){
            PauseMusic("GameMusic");
        }
    }

    public void PlayMusic (String name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
        S.source.Play();
    }

    public void PauseMusic (String name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
        S.source.Stop();
    }



}
