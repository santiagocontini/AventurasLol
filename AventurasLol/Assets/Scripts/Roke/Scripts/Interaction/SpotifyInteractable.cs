using UnityEngine;

public class SpotifyInteractable : Interactable
{
    protected override void Interact()
    {
        SpotifyUI.Instance.Open();
    }
}