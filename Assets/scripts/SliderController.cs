using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider engineSlider; // Slider for engine sound
    [SerializeField] private AudioSource[] engineAudioSources; // Array of AudioSources for engine sounds

    private const string EngineVolumePrefKey = "EngineVolume"; // Unified key for engine volume

    private void Start()
    {
        // Load and set the slider value from PlayerPrefs
        float savedEngineValue = PlayerPrefs.GetFloat(EngineVolumePrefKey, 0.5f); // Default to 0.5f
        engineSlider.value = savedEngineValue;

        // Apply the initial volume to the engine AudioSources
        SetVolume(engineAudioSources, savedEngineValue);

        // Add a listener to the slider to save the value and update volume when it changes
        engineSlider.onValueChanged.AddListener(OnEngineSliderValueChanged);
    }

    private void OnEngineSliderValueChanged(float value)
    {
        // Save the engine volume value to PlayerPrefs
        PlayerPrefs.SetFloat(EngineVolumePrefKey, value);
        PlayerPrefs.Save(); // Ensure the changes are written immediately

        // Update the volume of all engine AudioSources
        SetVolume(engineAudioSources, value);

        // Notify all CarAudioManagers to apply the new volume
        CarAudioManager[] carAudioManagers = FindObjectsOfType<CarAudioManager>();
        foreach (var manager in carAudioManagers)
        {
            manager.ApplySavedVolume();
        }
    }

    private void SetVolume(AudioSource[] audioSources, float volume)
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
