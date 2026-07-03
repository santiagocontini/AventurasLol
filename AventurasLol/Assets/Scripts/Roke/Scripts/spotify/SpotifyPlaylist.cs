using UnityEngine;

public class SpotifyPlaylist : MonoBehaviour
{
    [SerializeField] private SongData[] songs;

    public SongData[] Songs => songs;

    public int SongCount => songs.Length;

    public SongData GetSong(int index)
    {
        if (index < 0 || index >= songs.Length)
            return null;

        return songs[index];
    }

    public SongData GetRandomSong()
    {
        if (songs.Length == 0)
            return null;

        return songs[Random.Range(0, songs.Length)];
    }

    public int GetSongIndex(SongData song)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i] == song)
                return i;
        }

        return -1;
    }
}