using UnityEngine;

public class DepartmentManager : MonoBehaviour
{
    public static DepartmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (GameStateManager.Instance.IsState(GameState.LeaveStudio))
        {
            GameStateManager.Instance.ChangeState(GameState.HaveFun);
        }
    }
}