using UnityEngine;

public class CarAudioManager : MonoBehaviour
{
    private void Start()
    {
        // Retrieve the saved engine volume setting
        float savedEngineVolume = PlayerPrefs.GetFloat("EngineSliderValue", 0.5f); // Default to 0.5f

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
}
