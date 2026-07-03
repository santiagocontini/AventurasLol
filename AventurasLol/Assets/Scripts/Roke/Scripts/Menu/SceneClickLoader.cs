using UnityEngine;

public class SceneClickLoader : MonoBehaviour
{
    [Header("Escena")]
    [SerializeField] private string nextScene;

    [Header("Configuración")]
    [SerializeField] private float clickDelay = 0.5f;

    private bool canContinue;

    private void Start()
    {
        Invoke(nameof(EnableContinue), clickDelay);
    }

    private void Update()
    {
        if (!canContinue)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            SceneController.Instance.LoadScene(nextScene);
        }
    }

    private void EnableContinue()
    {
        canContinue = true;
    }
}