using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("HUD")]
    [SerializeField] private HUD hud;

    [Header("Diálogos")]
    [SerializeField] private DialogueUI dialogueUI;

    [Header("Pausa")]
    [SerializeField] private PauseMenu pauseMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public HUD HUD => hud;

    public DialogueUI Dialogue => dialogueUI;

    public PauseMenu Pause => pauseMenu;
}