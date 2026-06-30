using UnityEngine;

public class FriendInteractable : Interactable
{
    [TextArea]
    [SerializeField] private string[] dialogues;

    protected override void Interact()
    {
        if (dialogues == null || dialogues.Length == 0)
            return;

        int randomIndex = Random.Range(0, dialogues.Length);

        UIManager.Instance.Dialogue.Show(dialogues[randomIndex]);
    }
}