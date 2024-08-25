/*using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public static AudioSettingsManager Instance { get; private set; }

    private const string EngineVolumePrefKey = "EngineVolume";
    private float engineVolume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            LoadSettings();
        }
    }

    private void LoadSettings()
    {
        engineVolume = PlayerPrefs.GetFloat(EngineVolumePrefKey, 1f);
    }

    public void SetEngineVolume(float volume)
    {
        engineVolume = volume;
        PlayerPrefs.SetFloat(EngineVolumePrefKey, volume);
        PlayerPrefs.Save();
    }

    public float GetEngineVolume()
    {
        return engineVolume;
    }

    public void ApplyVolumeToAudioSource(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.volume = engineVolume;
        }
    }
}
*/