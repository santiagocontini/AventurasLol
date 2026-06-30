using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [Header("Estado actual")]
    [SerializeField]
    private GameState currentState = GameState.Intro;

    public GameState CurrentState => currentState;

    public event Action<GameState> OnStateChanged;

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
        }
    }

    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        Debug.Log($"Nuevo estado: {currentState}");

        OnStateChanged?.Invoke(currentState);
    }

    public bool IsState(GameState state)
    {
        return currentState == state;
    }
}