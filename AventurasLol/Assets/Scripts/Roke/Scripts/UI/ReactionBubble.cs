using TMPro;
using UnityEngine;

public class ReactionBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bubbleText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show(string text, float duration = 2f)
    {
        bubbleText.text = text;

        gameObject.SetActive(true);

        CancelInvoke();

        Invoke(nameof(Hide), duration);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Camera.main != null)
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}