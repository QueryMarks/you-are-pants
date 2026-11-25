using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    [SerializeField] private Slider musicSlider;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource =  GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(false, backgroundMusic);
        }
        //musicSlider.onValueChanged.AddListener(delegate { SetVolume(musicSlider.value); });
    }
    public static void SetVolume(float volume)
    {
        Instance.audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public static void  PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            Instance.audioSource.clip = audioClip;
        }
        if (Instance.audioSource.clip != null)
        {
            if (resetSong)
            {
                Instance.audioSource.Stop();
            }
            Instance.audioSource.Play();
        }
    }
    public static void PauseBackgroundMusic()
    {
        Instance.audioSource.Pause();
    }
    /*
    public void UpdateSlider(Slider newSlider)
    {
        musicSlider = newSlider;
        musicSlider.SetValueWithoutNotify(audioSource.volume);
        musicSlider.onValueChanged.AddListener(value => SetVolume(value));
    }*/
    public float GetVolume()
    {
        return audioSource.volume;
    }
    public void ConnectSlider(Slider slider)
    {
        musicSlider = slider;
        musicSlider.onValueChanged.RemoveAllListeners();
        musicSlider.SetValueWithoutNotify(audioSource.volume);
        musicSlider.onValueChanged.AddListener(SetVolume);
    }

}
