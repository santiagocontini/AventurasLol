using UnityEngine;

public class SearchableInteractable : Interactable
{
    [Header("Mensajes")]

    [TextArea]
    [SerializeField] private string normalMessage;

    [TextArea]
    [SerializeField] private string searchMessage;

    [TextArea]
    [SerializeField] private string foundMessage = "¡Acá está la llave!";

    private bool isCorrectObject;

    public void SetCorrectObject(bool value)
    {
        isCorrectObject = value;
    }

    protected override void Interact()
    {
        StoryEventsManager.Instance.OnSearchInteractable(
            isCorrectObject,
            normalMessage,
            searchMessage,
            foundMessage
        );
    }
}