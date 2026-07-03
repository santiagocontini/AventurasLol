using UnityEngine;
using UnityEngine.UI;

public class SpotifyControls : MonoBehaviour
{
    [Header("Botones")]
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button shuffleButton;

    [Header("Sprites")]
    [SerializeField] private Image playPauseImage;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;

    [Header("Playlist")]
    [SerializeField] private SpotifyPlaylist playlist;

    private bool songFinished;

    private void Start()
    {
        UpdateButton();
    }

    private void Update()
    {
        UpdateButton();
        CheckSongFinished();
    }

    private void CheckSongFinished()
    {
        if (SpotifyPlayer.Instance == null)
            return;

        if (SpotifyPlayer.Instance.CurrentSong == null)
            return;

        if (SpotifyPlayer.Instance.IsPlaying)
        {
            songFinished = false;
            return;
        }

        if (songFinished)
            return;

        if (SpotifyPlayer.Instance.CurrentTime >= SpotifyPlayer.Instance.Duration - 0.05f)
        {
            songFinished = true;
            NextSong();
        }
    }

    public void TogglePlayPause()
    {
        if (SpotifyPlayer.Instance == null)
            return;

        if (SpotifyPlayer.Instance.IsPlaying)
            SpotifyPlayer.Instance.PauseSong();
        else
            SpotifyPlayer.Instance.ResumeSong();

        UpdateButton();
    }

    public void NextSong()
    {
        if (playlist == null)
            return;

        SongData current = SpotifyPlayer.Instance.CurrentSong;

        if (current == null)
            return;

        int index = playlist.GetSongIndex(current);
        index++;

        if (index >= playlist.SongCount)
            index = 0;

        SpotifyUI.Instance.SelectSong(playlist.GetSong(index));
    }

    public void PreviousSong()
    {
        if (playlist == null)
            return;

        SongData current = SpotifyPlayer.Instance.CurrentSong;

        if (current == null)
            return;

        int index = playlist.GetSongIndex(current);
        index--;

        if (index < 0)
            index = playlist.SongCount - 1;

        SpotifyUI.Instance.SelectSong(playlist.GetSong(index));
    }

    public void ShuffleSong()
    {
        if (playlist == null)
            return;

        SongData randomSong = playlist.GetRandomSong();

        if (randomSong != null)
            SpotifyUI.Instance.SelectSong(randomSong);
    }

    private void UpdateButton()
    {
        if (playPauseImage == null || SpotifyPlayer.Instance == null)
            return;

        playPauseImage.sprite = SpotifyPlayer.Instance.IsPlaying
            ? pauseSprite
            : playSprite;
    }
}