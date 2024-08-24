using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioClip backgroundMusicClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeMusic();
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    private void Start()
    {
        InitializeMusic();
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

        musicAudioSource.Play(); // Start playing music immediately
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }
}
