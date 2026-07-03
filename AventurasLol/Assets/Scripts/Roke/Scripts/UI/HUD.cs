using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private TextMeshProUGUI interactionText;

    private void Start()
    {
        ActualizarObjetivo();

        if (interactionText != null)
            interactionText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (GameStateManager.Instance != null)
            GameStateManager.Instance.OnStateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        if (GameStateManager.Instance != null)
            GameStateManager.Instance.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameState newState)
    {
        ActualizarObjetivo();
    }

    private void ActualizarObjetivo()
    {
        if (GameStateManager.Instance == null)
            return;

        stateText.text = GameStateDatabase.GetObjective(GameStateManager.Instance.CurrentState);
    }

    public void ShowInteraction(string text)
    {
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);
    }

    public void HideInteraction()
    {
        interactionText.gameObject.SetActive(false);
    }
}