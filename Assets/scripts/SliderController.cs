using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource[] audioSources; // Array of AudioSources to apply volume to

    private const string SliderPrefKey = "SliderValue"; // Key for PlayerPrefs

    private void Start()
    {
        // Load and set the slider value from PlayerPrefs
        float savedValue = PlayerPrefs.GetFloat(SliderPrefKey, 0.5f); // Default value is 0.5f
        slider.value = savedValue;
        
        // Apply the initial volume to AudioSources
        SetVolume(savedValue);

        // Add a listener to the slider to save the value and update volume when it changes
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Save the value to PlayerPrefs
        PlayerPrefs.SetFloat(SliderPrefKey, value);

        // Update the volume of all AudioSources
        SetVolume(value);
    }

    private void SetVolume(float volume)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;
                Debug.Log($"Volume set to {volume} on AudioSource {audioSource.name}");
            }
        }
    }

}
