using UnityEngine;

public class MateUI : MonoBehaviour
{
    public static MateUI Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        panel.SetActive(false);
    }

    public void Open()
    {
        panel.SetActive(true);

        if (player != null)
            player.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        panel.SetActive(false);

        if (player != null)
            player.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}