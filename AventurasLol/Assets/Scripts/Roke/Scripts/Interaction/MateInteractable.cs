using UnityEngine;

public class MateInteractable : Interactable
{
    protected override void Interact()
    {
        MateUI.Instance.Open();
    }
}