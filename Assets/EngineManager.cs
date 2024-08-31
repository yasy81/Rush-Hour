using UnityEngine;
using UnityEngine.UI;

public class EngineManager : MonoBehaviour
{
    [SerializeField] private Slider engineVolumeSlider;

    private void Start()
    {
        // Load saved volume settings and assign it to the slider
        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            engineVolumeSlider.value = PlayerPrefs.GetFloat("EngineVolume");
        }

        engineVolumeSlider.onValueChanged.AddListener(SetEngineVolume);
    }

    private void SetEngineVolume(float volume)
    {
        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("EngineVolume", volume);
    }
}