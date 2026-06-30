using TMPro;
using UnityEngine;

public class SongButton : MonoBehaviour
{
    [Header("Canción")]
    [SerializeField] private SongData song;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI songNameText;
    [SerializeField] private GameObject playingIcon;

    [Header("Colores")]
    [SerializeField] private Color normalColor = Color.white;

    // Verde oficial aproximado de Spotify
    [SerializeField] private Color playingColor = new Color32(30, 215, 96, 255);

    private void Start()
    {
        if (SpotifySongList.Instance != null)
        {
            SpotifySongList.Instance.RegisterButton(this);
        }

        Refresh(SpotifyPlayer.Instance != null ? SpotifyPlayer.Instance.CurrentSong : null);
    }

    public void PlaySong()
    {
        SpotifyUI.Instance.SelectSong(song);
    }

    public void Refresh(SongData currentSong)
    {
        bool isPlaying = currentSong == song;

        if (songNameText != null)
        {
            songNameText.color = isPlaying ? playingColor : normalColor;
        }

        if (playingIcon != null)
        {
            playingIcon.SetActive(isPlaying);
        }
    }
}