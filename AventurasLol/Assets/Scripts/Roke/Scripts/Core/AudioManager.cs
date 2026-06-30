using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer mixer;

    private const string MASTER = "MasterVolume";
    private const string MUSIC = "MusicVolume";
    private const string SFX = "SFXVolume";
    private const string VOICE = "VoiceVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadVolumes()
    {
        SetMasterVolume(PlayerPrefs.GetFloat(MASTER, 1f));
        SetMusicVolume(PlayerPrefs.GetFloat(MUSIC, 1f));
        SetSFXVolume(PlayerPrefs.GetFloat(SFX, 1f));
        SetVoiceVolume(PlayerPrefs.GetFloat(VOICE, 1f));
    }

    public void SetMasterVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);

        mixer.SetFloat(MASTER, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(MASTER, value);
    }

    public void SetMusicVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);

        mixer.SetFloat(MUSIC, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(MUSIC, value);
    }

    public void SetSFXVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);

        mixer.SetFloat(SFX, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(SFX, value);
    }

    public void SetVoiceVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);

        mixer.SetFloat(VOICE, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(VOICE, value);
    }
}