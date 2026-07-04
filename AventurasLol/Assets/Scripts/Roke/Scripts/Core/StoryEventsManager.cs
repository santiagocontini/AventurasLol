using UnityEngine;

public class StoryEventsManager : MonoBehaviour
{
    public static StoryEventsManager Instance;

    [Header("Escenas")]
    [SerializeField] private string kidnappingScene = "Secuestro";

    [Header("Fin Demo")]
    [SerializeField] private string endDemoScene = "FinDemo";

    private bool keyFound;

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

    private void OnEnable()
    {
        if (GameStateManager.Instance != null)
            GameStateManager.Instance.OnStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        if (GameStateManager.Instance != null)
            GameStateManager.Instance.OnStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.UsePC:

                if (SpotifyPlayer.Instance != null)
                {
                    SpotifyPlayer.Instance.StopSong();
                }

                SceneController.Instance.LoadScene(kidnappingScene);

                break;

            case GameState.FindKey:

                ChooseRandomObject();

                break;
        }
    }

    //====================================================
    // PC DEL ESTUDIO
    //====================================================

    public void OnStudyPCInteraction()
    {
        switch (GameStateManager.Instance.CurrentState)
        {
            case GameState.LeaveStudio:

                UIManager.Instance.Dialogue.Show(
                    "No es momento de usar la computadora."
                );

                break;

            case GameState.HaveFun:

                UIManager.Instance.Dialogue.Show(
                    "Después la uso, primero voy a divertirme con los chicos."
                );

                break;

            case GameState.UsePC:

                UIManager.Instance.Dialogue.Show(
                    "No hay nadie conectado en Discord..."
                );

                GameStateManager.Instance.ChangeState(
                    GameState.NeedKey
                );

                break;

            case GameState.NeedKey:

                UIManager.Instance.Dialogue.Show(
                    "No hay nadie conectado."
                );

                break;

            case GameState.FindKey:

                UIManager.Instance.Dialogue.Show(
                    "Tengo que encontrar la llave."
                );

                break;

            case GameState.LeaveApartment:

                UIManager.Instance.Dialogue.Show(
                    "Ya tengo la llave."
                );

                break;
        }
    }

    //====================================================
    // PUERTA DE SALIDA
    //====================================================

    public void OnExitDoorInteraction()
    {
        switch (GameStateManager.Instance.CurrentState)
        {
            case GameState.HaveFun:

                UIManager.Instance.Dialogue.Show(
                    "No es momento de salir."
                );

                break;

            case GameState.NeedKey:

                UIManager.Instance.Dialogue.Show(
                    "Mmm... necesito la llave."
                );

                GameStateManager.Instance.ChangeState(
                    GameState.FindKey
                );

                break;

            case GameState.FindKey:

                UIManager.Instance.Dialogue.Show(
                    "Primero tengo que encontrar la llave."
                );

                break;

            case GameState.LeaveApartment:

                SceneController.Instance.LoadScene(
                    endDemoScene
                );

                break;
        }
    }

    //====================================================
    // OBJETOS PARA BUSCAR
    //====================================================

    public void OnSearchInteractable(
        bool correctObject,
        string normalMessage,
        string searchMessage,
        string foundMessage)
    {
        GameState state = GameStateManager.Instance.CurrentState;

        if (state != GameState.FindKey)
        {
            UIManager.Instance.Dialogue.Show(normalMessage);
            return;
        }

        if (keyFound)
            return;

        if (correctObject)
        {
            keyFound = true;

            UIManager.Instance.Dialogue.Show(foundMessage);

            GameStateManager.Instance.ChangeState(
                GameState.LeaveApartment
            );

            return;
        }

        UIManager.Instance.Dialogue.Show(searchMessage);
    }

    //====================================================
    // ELIGE UN OBJETO AL AZAR
    //====================================================

    private void ChooseRandomObject()
    {
        SearchableInteractable[] objects =
            FindObjectsByType<SearchableInteractable>(
                FindObjectsSortMode.None);

        if (objects.Length == 0)
            return;

        foreach (SearchableInteractable obj in objects)
        {
            obj.SetCorrectObject(false);
        }

        int random = Random.Range(0, objects.Length);

        objects[random].SetCorrectObject(true);

        Debug.Log("La llave está en: " + objects[random].name);
    }
}