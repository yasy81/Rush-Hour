/*using UnityEngine;
using UnityEngine.UI; 
public class CarAudioManager : MonoBehaviour
{
    private const string EngineVolumePrefKey = "EngineVolume"; // Unified key for engine volume
    [SerializeField] private Slider engineVolumeSlider;

    private void Start()
    {
        // Apply the saved engine volume at the start of the scene
        ApplySavedVolume();
        // Load and set the slider value from PlayerPrefs
        float savedEngineValue = PlayerPrefs.GetFloat(EngineVolumePrefKey, 0.5f); // Default to 0.5f
        engineVolumeSlider.value = savedEngineValue;

        // Add a listener to the slider to save the value when it changes
        engineVolumeSlider.onValueChanged.AddListener(OnEngineVolumeSliderValueChanged);
    }

    public void ApplySavedVolume()
    {
        // Retrieve the saved engine volume setting
        float savedEngineVolume = PlayerPrefs.GetFloat(EngineVolumePrefKey, 0.5f); // Default to 0.5f

        // Find all cars in the scene
        Car[] cars = FindObjectsOfType<Car>();

        // Apply the saved engine volume to each car's AudioSource
        foreach (Car car in cars)
        {
            AudioSource audioSource = car.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = savedEngineVolume;
                Debug.Log($"Engine volume set to {savedEngineVolume} on Car {car.name}");
            }
        }
    }

    private void OnEngineVolumeSliderValueChanged(float value)
    {
        // Save the engine volume value to PlayerPrefs
        PlayerPrefs.SetFloat(EngineVolumePrefKey, value);
        PlayerPrefs.Save(); // Ensure the changes are written immediately
    }
}
*/