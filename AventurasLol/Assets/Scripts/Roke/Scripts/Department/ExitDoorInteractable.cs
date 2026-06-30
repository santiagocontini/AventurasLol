using UnityEngine;

public class ExitDoorInteractable : Interactable
{
    protected override void Interact()
    {
        StoryEventsManager.Instance.OnExitDoorInteraction();
    }
}