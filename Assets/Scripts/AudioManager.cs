using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager Instance;

    public bool Muted = false;

    void Awake()
    {
        if(Instance == null)  //It makes it so where there can't be 2 AudioManagers in a Scene
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Muted == true)
        {
            Muted = false;
            Debug.Log("Un-Mute");
        } else if (Input.GetKeyDown(KeyCode.M) && Muted == false)
        {
            Muted = true;
            Debug.Log("Mute");
        }

        foreach(Sound s in Sounds)
        {
            if (Muted == true)
            {
                s.Source.volume = 0f;
            }
            else
            {
                s.Source.volume = s.Volume;
            }
        }
    }


    public void Play (string name)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.Name == name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        S.Source.Play();
    }
}
