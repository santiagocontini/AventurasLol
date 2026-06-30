using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager Instance;

    [Header("Capítulo Actual")]
    [SerializeField]
    private Chapter currentChapter = Chapter.Department;

    public Chapter CurrentChapter => currentChapter;

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

    public void ChangeChapter(Chapter newChapter)
    {
        currentChapter = newChapter;

        Debug.Log("Capítulo actual: " + currentChapter);
    }

    public bool IsChapter(Chapter chapter)
    {
        return currentChapter == chapter;
    }
}