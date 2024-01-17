using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    private float lastSliderValue;
    void Start()
    {
        // Make sure you have assigned the AudioSource component to audioSource in the Inspector
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned to AutoSlider script!");
            return;
        }

        // Set the slider max value to match the audio clip length
        slider.maxValue = audioSource.clip.length;
        lastSliderValue = slider.minValue;
    }

    void Update()
    {
        // Increase the slider value based on the audio playback time
        slider.value = audioSource.time;

        // Reset the slider to the minimum value when it reaches the maximum value
        if (slider.value >= slider.maxValue)
        {
            slider.value = slider.minValue;
        }
    }
}
