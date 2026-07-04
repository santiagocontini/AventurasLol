using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioLowPassFilter))]
public class SpotifyPlayer : MonoBehaviour
{
    public static SpotifyPlayer Instance;

    [SerializeField] private AudioMixerGroup musicGroup;

    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;

    private SongData currentSong;

    public SongData CurrentSong => currentSong;
    public bool IsPlaying => audioSource.isPlaying;
    public float CurrentTime => audioSource.time;

    public float Duration
    {
        get
        {
            if (audioSource.clip == null)
                return 0f;

            return audioSource.clip.length;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();

        if (musicGroup != null)
            audioSource.outputAudioMixerGroup = musicGroup;

        SetDepartmentAudio();
    }

    public void PlaySong(SongData song)
    {
        if (song == null || song.audioClip == null)
            return;

        if (currentSong == song && audioSource.isPlaying)
            return;

        currentSong = song;

        audioSource.clip = song.audioClip;
        audioSource.Play();
    }

    public void PauseSong()
    {
        audioSource.Pause();
    }

    public void ResumeSong()
    {
        audioSource.UnPause();
    }

    public void StopSong()
    {
        audioSource.Stop();
        audioSource.clip = null;
        currentSong = null;
    }

    public void Seek(float normalizedValue)
    {
        if (audioSource.clip == null)
            return;

        normalizedValue = Mathf.Clamp01(normalizedValue);
        audioSource.time = normalizedValue * audioSource.clip.length;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }

    public void SetDepartmentAudio()
    {
        audioSource.volume = 1f;
        lowPassFilter.cutoffFrequency = 22000f;
    }

    public void SetStudyAudio()
    {
        audioSource.volume = 0.3f;
        lowPassFilter.cutoffFrequency = 1200f;
    }
}