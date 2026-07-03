using UnityEngine;

public class ComputerInteractable : Interactable
{
    protected override void Interact()
    {
        StoryEventsManager.Instance.OnStudyPCInteraction();
    }
}