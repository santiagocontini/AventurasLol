using System.Collections.Generic;
using UnityEngine;

public class SpotifySongList : MonoBehaviour
{
    public static SpotifySongList Instance;

    private readonly List<SongButton> buttons = new();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterButton(SongButton button)
    {
        if (!buttons.Contains(button))
        {
            buttons.Add(button);
        }
    }

    public void UpdateSelection(SongData currentSong)
    {
        foreach (SongButton button in buttons)
        {
            button.Refresh(currentSong);
        }
    }
}