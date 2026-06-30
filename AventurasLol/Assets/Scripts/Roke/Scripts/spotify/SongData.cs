using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Las Aventuras Loleras/Song")]
public class SongData : ScriptableObject
{
    [Header("Información")]
    public string songName;

    public string artist;

    [Header("Audio")]
    public AudioClip audioClip;

    [Header("Imagen de reproducción")]
    public Sprite currentSongImage;

    [Header("Diversión")]
    public SongEffect[] effects;
}