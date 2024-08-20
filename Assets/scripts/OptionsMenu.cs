using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider engineVolumeSlider;

    private void Start()
    {
        // Initialize the slider value based on PlayerPrefs or a default value
        engineVolumeSlider.value = PlayerPrefs.GetFloat("EngineVolume", 1f);

        // Update the volume at the start
        SetEngineVolume(engineVolumeSlider.value);

        // Add a listener to the slider to call the method whenever the slider value changes
        engineVolumeSlider.onValueChanged.AddListener(SetEngineVolume);
    }

    private void SetEngineVolume(float volume)
    {
        // Save the volume setting
        PlayerPrefs.SetFloat("EngineVolume", volume);
    }
}
