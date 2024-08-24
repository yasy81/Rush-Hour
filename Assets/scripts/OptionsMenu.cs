using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider engineVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    private const string EngineVolumePrefKey = "EngineVolume"; // Unified key for engine volume
    private const string MusicVolumePrefKey = "MusicVolume";   // Key for music volume

    private MusicManager musicManager;

    private void Start()
    {
        // Initialize the slider values based on PlayerPrefs or default values
        engineVolumeSlider.value = PlayerPrefs.GetFloat(EngineVolumePrefKey, 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumePrefKey, 1f);

        // Find the MusicManager instance in the scene
        musicManager = FindObjectOfType<MusicManager>();

        // Update the volumes at the start
        SetEngineVolume(engineVolumeSlider.value);
        SetMusicVolume(musicVolumeSlider.value);

        // Add listeners to the sliders to call the methods whenever the slider values change
        engineVolumeSlider.onValueChanged.AddListener(SetEngineVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void SetEngineVolume(float volume)
    {
        PlayerPrefs.SetFloat(EngineVolumePrefKey, volume);
        PlayerPrefs.Save(); // Ensure the changes are saved immediately
        ApplyVolumeToEngineAudioSources(volume);
    }

    private void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicVolumePrefKey, volume);
        PlayerPrefs.Save(); // Ensure the changes are saved immediately

        if (musicManager != null)
        {
            musicManager.SetMusicVolume(volume);
        }
    }

    private void ApplyVolumeToEngineAudioSources(float volume)
    {
        Car[] cars = FindObjectsOfType<Car>();
        foreach (Car car in cars)
        {
            AudioSource audioSource = car.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = volume;
                Debug.Log($"Engine volume set to {volume} on Car {car.name}");
            }
        }
    }
}
