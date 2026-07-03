using UnityEngine;

public class DepartmentStateController : MonoBehaviour
{
    [Header("Objetos del departamento")]
    [SerializeField] private GameObject friends;
    [SerializeField] private GameObject livingNotebook;

    [Header("UI")]
    [SerializeField] private GameObject friendsPanel;

    private void OnEnable()
    {
        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.OnStateChanged += OnGameStateChanged;
        }
    }

    private void OnDisable()
    {
        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.OnStateChanged -= OnGameStateChanged;
        }
    }

    private void Start()
    {
        RefreshWorld();
    }

    private void OnGameStateChanged(GameState state)
    {
        RefreshWorld();
    }

    public void RefreshWorld()
    {
        if (GameStateManager.Instance == null)
            return;

        GameState state = GameStateManager.Instance.CurrentState;

        switch (state)
        {
            case GameState.HaveFun:

                friends.SetActive(true);
                livingNotebook.SetActive(true);

                if (friendsPanel != null)
                    friendsPanel.SetActive(true);

                break;

            case GameState.UsePC:
            case GameState.NeedKey:
            case GameState.FindKey:
            case GameState.LeaveApartment:

                friends.SetActive(false);
                livingNotebook.SetActive(false);

                if (friendsPanel != null)
                    friendsPanel.SetActive(false);

                break;

            default:

                friends.SetActive(true);
                livingNotebook.SetActive(true);

                if (friendsPanel != null)
                    friendsPanel.SetActive(true);

                break;
        }
    }
}