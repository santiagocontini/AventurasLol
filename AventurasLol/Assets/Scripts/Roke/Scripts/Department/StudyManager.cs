using UnityEngine;

public class StudyManager : MonoBehaviour
{
    private void Start()
    {
        if (GameStateManager.Instance.IsState(GameState.Intro))
        {
            GameStateManager.Instance.ChangeState(GameState.LeaveStudio);
        }

        if (SpotifyPlayer.Instance != null)
        {
SpotifyPlayer.Instance.SetStudyAudio();        }
    }
}