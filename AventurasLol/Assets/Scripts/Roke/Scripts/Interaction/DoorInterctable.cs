using UnityEngine;

public class DoorInteractable : Interactable
{
    [Header("Destino")]
    [SerializeField] private string destinationScene;

    [SerializeField] private string destinationSpawn;

    [Header("Requisitos")]
    [SerializeField] private bool requiresGameState = false;

    [SerializeField] private GameState requiredState;

    protected override void Interact()
    {
        if (requiresGameState)
        {
            if (!GameStateManager.Instance.IsState(requiredState))
                return;
        }

        SpawnManager.Instance.SetNextSpawn(destinationSpawn);

        SceneController.Instance.LoadScene(destinationScene);
    }
}