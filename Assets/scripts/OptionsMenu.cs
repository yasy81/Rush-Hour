using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider engineVolumeSlider;
    //[SerializeField] private Slider musicVolumeSlider;

    //[SerializeField] private AudioSource[] engineAudioSource;

    private const string EngineVolumePrefKey = "EngineVolume"; // Unified key for engine volume
   //private const string MusicVolumePrefKey = "MusicVolume";   // Key for music volume

    private MusicManager musicManager;

    private void Start()
    {
        // Initialize the slider values based on PlayerPrefs or default values
        engineVolumeSlider.value = PlayerPrefs.GetFloat(EngineVolumePrefKey, 1f);
       // musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumePrefKey, 1f);

        // Find the MusicManager instance in the scene
        musicManager = FindObjectOfType<MusicManager>();

        // Update the volumes at the start
        SetEngineVolume(engineVolumeSlider.value);
        //SetMusicVolume(musicVolumeSlider.value);

        // Add listeners to the sliders to call the methods whenever the slider values change
        engineVolumeSlider.onValueChanged.AddListener(SetEngineVolume);
       // musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);

       if (engineAudioSource != null)
        {
            engineAudioSource.enabled = false;
        }
    }

    private void OnEnable()
    {
        // Disable the engine sound when the options menu is enabled
        if (engineAudioSource != null)
        {
            engineAudioSource.enabled = false;
        }
    }

    private void OnDisable()
    {
        // Re-enable the engine sound when the options menu is disabled
        if (engineAudioSource != null)
        {
            engineAudioSource.enabled = true;
        }
    }

    private void SetEngineVolume(float volume)
    {
        PlayerPrefs.SetFloat(EngineVolumePrefKey, volume);
        PlayerPrefs.Save(); // Ensure the changes are saved immediately

        // You don't need to apply the engine volume here if the engine sound is not supposed to play in the options menu
    }

   /* private void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicVolumePrefKey, volume);
        PlayerPrefs.Save(); // Ensure the changes are saved immediately

        if (musicManager != null)
        {
            musicManager.SetMusicVolume(volume);
        }
    }*/
}
