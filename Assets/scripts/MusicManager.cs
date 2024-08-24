using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource music;
    public GameObject ObjectMusic;

    public Slider volumeSlider;
    private float MusicVolume = 1f;


    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        music = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volume",1f);
        music.volume = MusicVolume;
        volumeSlider.value = MusicVolume;

        volumeSlider.onValueChanged.AddListener(VolumeUpdater);
        
    }

    private void Update()
    {
        music.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
        
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

}
