/*using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider engineVolumeSlider; // Slider for engine sound

    private const string EngineVolumePrefKey = "EngineVolume"; // Unified key for engine volume

    private void Start()
    {
        // Load and set the slider value from PlayerPrefs
        float savedEngineValue = PlayerPrefs.GetFloat(EngineVolumePrefKey, 0.5f); // Default to 0.5f
        engineVolumeSlider.value = savedEngineValue;

        // Add a listener to the slider to save the value when it changes
        engineVolumeSlider.onValueChanged.AddListener(OnEngineVolumeSliderValueChanged);
    }

    private void OnEngineVolumeSliderValueChanged(float value)
    {
        // Save the engine volume value to PlayerPrefs
        PlayerPrefs.SetFloat(EngineVolumePrefKey, value);
        PlayerPrefs.Save(); // Ensure the changes are written immediately
    }
}
*/