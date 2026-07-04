using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float autoHideTime = 2.5f;

    private Coroutine hideCoroutine;

    public bool IsOpen => panel.activeSelf;

    public void Show(string text)
    {
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        panel.SetActive(true);
        dialogueText.text = text;

        hideCoroutine = StartCoroutine(AutoHide());
    }

    public void Hide()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
            hideCoroutine = null;
        }

        panel.SetActive(false);
    }

    private IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(autoHideTime);

        Hide();
    }
}