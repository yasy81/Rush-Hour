using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    public Slider volumeSlider;
    private float MusicVolume = 1f;

    private void Start()
    {
        music.Play();
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










    /*private static MusicManager instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioClip backgroundMusicClip;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeMusic(); // Initialize music settings
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    private void InitializeMusic()
    {
        if (musicAudioSource == null)
        {
            musicAudioSource = gameObject.AddComponent<AudioSource>();
        }

        musicAudioSource.clip = backgroundMusicClip;
        musicAudioSource.loop = true;
        musicAudioSource.playOnAwake = false;

        // Apply the saved volume when initializing
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SetMusicVolume(savedMusicVolume);

        // Start playing music if it's not already playing
        if (!musicAudioSource.isPlaying)
        {
            musicAudioSource.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }*/
}
