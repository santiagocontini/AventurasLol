using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections;

public class DialogueManagerMapa : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSON;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    [Header("Fade")]
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    [Header("Typewriter")]
    public float typingSpeed = 0.03f;

    [Header("Player")]
    public MovimientoDelPersonaje player;

    private Story story;
    private Coroutine typingCoroutine;

    private bool isTyping = false;
    private bool dialogueStarted = false;

    private string currentLine;

    private void Start()
    {
        if (player != null)
        {
            player.canMove = false;
        }

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }

        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 1f;
            fadeImage.color = c;

            yield return StartCoroutine(FadeIn());
        }

        yield return new WaitForSeconds(2f);

        StartDialogue();
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        Color c = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            c.a = Mathf.Lerp(
                1f,
                0f,
                elapsedTime / fadeDuration
            );

            fadeImage.color = c;

            yield return null;
        }

        c.a = 0f;
        fadeImage.color = c;
    }

    private void StartDialogue()
    {
        if (inkJSON == null)
        {
            Debug.LogError("No hay archivo Ink asignado.");
            return;
        }

        dialogueStarted = true;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }

        story = new Story(inkJSON.text);

        ContinueStory();
    }

    private void Update()
    {
        if (!dialogueStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteLine();
            }
            else
            {
                ContinueStory();
            }
        }
    }

    private void ContinueStory()
    {
        if (!story.canContinue)
        {
            EndDialogue();
            return;
        }

        currentLine = story.Continue().Trim();

        HandleTags();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(currentLine));
    }

    private void HandleTags()
    {
        foreach (string tag in story.currentTags)
        {
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
                continue;

            string key = splitTag[0].Trim().ToLower();
            string value = splitTag[1].Trim();

            if (key == "speaker")
            {
                if (nameText != null)
                {
                    nameText.text = value;
                }
            }
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;

        if (dialogueText != null)
        {
            dialogueText.text = "";
        }

        foreach (char letter in line)
        {
            if (dialogueText != null)
            {
                dialogueText.text += letter;
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void CompleteLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        if (dialogueText != null)
        {
            dialogueText.text = currentLine;
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }

        if (player != null)
        {
            player.canMove = true;
        }

        Debug.Log("Movimiento habilitado");
    }
}