using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private string nextSpawnPoint = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetNextSpawn(string spawnID)
    {
        nextSpawnPoint = spawnID;
    }

    public string GetNextSpawn()
    {
        return nextSpawnPoint;
    }

    public void ClearSpawn()
    {
        nextSpawnPoint = "";
    }
}