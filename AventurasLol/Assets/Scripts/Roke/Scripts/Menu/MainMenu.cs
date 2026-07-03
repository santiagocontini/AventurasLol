using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject panelAjustes;
    [SerializeField] private GameObject panelCreditos;

    public void PlayGame()
    {
        SceneController.Instance.LoadScene("derrota");
    }

    public void ContinueGame()
    {
        Debug.Log("No hay partida guardada.");
    }

    public void OpenSettings()
    {
        panelAjustes.SetActive(true);
    }

    public void CloseSettings()
    {
        panelAjustes.SetActive(false);
    }

    public void OpenCredits()
    {
        panelCreditos.SetActive(true);
    }

    public void CloseCredits()
    {
        panelCreditos.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}