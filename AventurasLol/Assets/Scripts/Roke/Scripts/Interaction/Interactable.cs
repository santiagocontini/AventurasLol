using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Interacción")]
    [SerializeField] private string interactionText = "[E] Interactuar";

    private bool playerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = true;

        UIManager.Instance.HUD.ShowInteraction(interactionText);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = false;

        UIManager.Instance.HUD.HideInteraction();
    }

    private void Update()
    {
        if (!playerInside)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    protected abstract void Interact();
}