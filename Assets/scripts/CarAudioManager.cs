using UnityEngine;

public class CarAudioManager : MonoBehaviour
{
    private void Start()
    {
        // Retrieve the saved volume setting
        float savedVolume = PlayerPrefs.GetFloat("SliderValue", 0.5f); // Default to 0.5f

        // Find all cars in the scene
        Car[] cars = FindObjectsOfType<Car>();

        // Apply the saved volume to each car's AudioSource
        foreach (Car car in cars)
        {
            AudioSource audioSource = car.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = savedVolume;
            }
        }
    }
}
