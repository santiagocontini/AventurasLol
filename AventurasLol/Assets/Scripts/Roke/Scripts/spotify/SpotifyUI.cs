using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpotifyUI : MonoBehaviour
{
    public static SpotifyUI Instance;

    [Header("UI")]
    [SerializeField] private GameObject spotifyPanel;

    [SerializeField] private Image currentSongImage;

    [SerializeField] private TextMeshProUGUI currentSongName;

    [SerializeField] private TextMeshProUGUI currentArtist;

    [Header("Player")]
    [SerializeField] private PlayerController playerController;

    private SongData selectedSong;
    private bool songChanged;

    public SongData SelectedSong => selectedSong;

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

        spotifyPanel.SetActive(false);

        if (currentSongImage != null)
            currentSongImage.enabled = false;

        if (currentSongName != null)
            currentSongName.text = "";

        if (currentArtist != null)
            currentArtist.text = "";
    }

    public void Open()
    {
        spotifyPanel.SetActive(true);

        if (playerController != null)
            playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        RefreshUI();

        if (SpotifySongList.Instance != null)
        {
            SpotifySongList.Instance.UpdateSelection(selectedSong);
        }
    }

    public void Close()
    {
        if (songChanged && selectedSong != null)
        {
            foreach (SongEffect effect in selectedSong.effects)
            {
                FriendManager.Instance.AddFun(effect.friend, effect.funChange);
            }

            songChanged = false;
        }

        spotifyPanel.SetActive(false);

        if (playerController != null)
            playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SelectSong(SongData song)
    {
        if (song == null)
            return;

        selectedSong = song;
        songChanged = true;

        SpotifyPlayer.Instance.PlaySong(song);

        RefreshUI();

        if (SpotifySongList.Instance != null)
        {
            SpotifySongList.Instance.UpdateSelection(selectedSong);
        }
    }

    private void RefreshUI()
    {
        if (selectedSong == null)
        {
            if (currentSongImage != null)
                currentSongImage.enabled = false;

            if (currentSongName != null)
                currentSongName.text = "";

            if (currentArtist != null)
                currentArtist.text = "";

            return;
        }

        if (currentSongImage != null)
        {
            currentSongImage.enabled = true;
            currentSongImage.sprite = selectedSong.currentSongImage;
        }

        if (currentSongName != null)
        {
            currentSongName.text = selectedSong.songName;
        }

        if (currentArtist != null)
        {
            currentArtist.text = selectedSong.artist;
        }
    }
}