using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public bool IsOpen => panel.activeSelf;

    private void Update()
    {
        if (!panel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.E))
        {
            Hide();
        }
    }

    public void Show(string text)
    {
        panel.SetActive(true);
        dialogueText.text = text;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}