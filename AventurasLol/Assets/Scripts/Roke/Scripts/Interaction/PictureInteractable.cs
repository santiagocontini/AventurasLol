using UnityEngine;

public class PictureInteractable : Interactable
{
    [Header("Imagen")]
    [SerializeField] private Sprite picture;

    protected override void Interact()
    {
        PictureViewer.Instance.ShowPicture(picture);
    }
}