using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;

    private bool isOpen;

    public bool IsOpen => isOpen;

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (UIManager.Instance.Dialogue.IsOpen)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOpen)
            {
                OpenPause();
            }
            else
            {
                if (settingsPanel.activeSelf)
                    CloseSettings();
                else
                    Resume();
            }
        }
    }

    public void OpenPause()
    {
        isOpen = true;

        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        isOpen = false;

        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenSettings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}