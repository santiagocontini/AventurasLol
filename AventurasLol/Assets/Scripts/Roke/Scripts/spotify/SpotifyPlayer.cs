using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SpotifyPlayer : MonoBehaviour
{
    public static SpotifyPlayer Instance;

    [SerializeField] private AudioMixerGroup musicGroup;

    private AudioSource audioSource;
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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        if (musicGroup != null)
            audioSource.outputAudioMixerGroup = musicGroup;
    }

    public void PlaySong(SongData song)
    {
        if (song == null || song.audioClip == null)
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
}