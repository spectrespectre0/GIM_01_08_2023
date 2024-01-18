using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    

    // Add your audio-related variables here
    private static AudioManager instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Use this method to play audio with your custom logic
    public void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Use this method to stop audio
    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Event handler for scene loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the easy level screen
        if (scene.name == "EasyLevel" || scene.name == "MedLevel" || scene.name == "HardLevel" || scene.name == "Tutorial")
        {
            // Stop the audio when entering the easy level screen
            StopAudio();
        }
        else
        {
            // Play the audio when entering any other scene
            PlayAudio();
        }
    }
}
