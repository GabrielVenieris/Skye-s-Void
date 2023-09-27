using UnityEngine.Audio;
using UnityEngine;
using JetBrains.Annotations;

/*
Lista de áudios e principais mecanismos de configuração
Nome (name); Volume(volume); Tom(pitch); Loop(loop)
*/


[System.Serializable]
public class Sound
{
   
   public string name;

   public AudioClip clip;

    [Range(0f, 1f)]
   public float volume;
   [Range(.1f, 3f)]
   public float picth;
   public bool loop;

    [HideInInspector]
    public AudioSource source;

}
