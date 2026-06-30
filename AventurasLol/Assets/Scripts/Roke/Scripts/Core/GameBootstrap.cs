using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private GameObject systemsPrefab;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(systemsPrefab);
        }
    }
}