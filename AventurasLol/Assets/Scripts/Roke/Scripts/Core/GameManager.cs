using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Capítulo Actual")]
    [SerializeField]
    private Chapter currentChapter = Chapter.Department;

    public Chapter CurrentChapter => currentChapter;

    private void Awake()
    {
        // Singleton
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

    public void ChangeChapter(Chapter newChapter)
    {
        currentChapter = newChapter;
    }
}