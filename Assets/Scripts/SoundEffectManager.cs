using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;
    private static AudioSource audioSource;
    private static AudioSource runAudioSource;

    private static SoundEffectLibrary soundEffectLibrary;
    [SerializeField] private Slider sfxSlider;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            runAudioSource = gameObject.AddComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    /*
    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }*/
    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
        runAudioSource.volume = volume;

    }
    /*
   public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }*/
    public static void Stop()
    {
        audioSource.Stop();
    }
    public static void PlayRun()
    {
        if (!runAudioSource.isPlaying)
        {
            AudioClip audioClip = soundEffectLibrary.GetRandomClip("Run");

            if (audioClip != null)
            {
                runAudioSource.PlayOneShot(audioClip);
            }
        }
    }

    public static void StopRun()
    {
        runAudioSource.Stop();
    }
    public float GetVolume()
    {
        return audioSource.volume;
    }
    public void ConnectSlider(Slider slider)
    {
        sfxSlider = slider;
        sfxSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.SetValueWithoutNotify(audioSource.volume);
        sfxSlider.onValueChanged.AddListener(SetVolume);
    }
}
