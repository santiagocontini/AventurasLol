using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpotifyProgressUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI")]
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private TextMeshProUGUI durationText;

    private bool isDragging = false;

    private void Update()
    {
        if (SpotifyPlayer.Instance == null)
            return;

        float duration = SpotifyPlayer.Instance.Duration;

        if (duration <= 0f)
        {
            progressSlider.value = 0f;

            currentTimeText.text = "0:00";
            durationText.text = "0:00";

            return;
        }

        if (!isDragging)
        {
            float current = SpotifyPlayer.Instance.CurrentTime;

            progressSlider.value = current / duration;

            currentTimeText.text = FormatTime(current);
        }

        durationText.text = FormatTime(duration);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        SpotifyPlayer.Instance.Seek(progressSlider.value);
    }

    public void OnSliderChanged(float value)
    {
        if (!isDragging)
            return;

        float current = value * SpotifyPlayer.Instance.Duration;

        currentTimeText.text = FormatTime(current);
    }

    private string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        int secs = Mathf.FloorToInt(seconds % 60);

        return $"{minutes}:{secs:00}";
    }
}