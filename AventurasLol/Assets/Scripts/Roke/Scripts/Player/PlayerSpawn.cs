using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        if (SpawnManager.Instance == null)
            return;

        string spawnID = SpawnManager.Instance.GetNextSpawn();

        if (string.IsNullOrEmpty(spawnID))
            return;

SpawnPoint[] spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);
        foreach (SpawnPoint point in spawnPoints)
        {
            if (point.SpawnID == spawnID)
            {
                transform.position = point.transform.position;
                break;
            }
        }

        SpawnManager.Instance.ClearSpawn();
    }
}