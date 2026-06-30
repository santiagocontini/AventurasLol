using UnityEngine;
using UnityEngine.UI;

public class PictureViewer : MonoBehaviour
{
    public static PictureViewer Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private Image pictureImage;

    private void Awake()
    {
        Instance = this;

        panel.SetActive(false);
    }

    private void Update()
    {
        if (!panel.activeSelf)
            return;

        if (Input.GetMouseButtonDown(0) ||
            Input.GetKeyDown(KeyCode.Escape))
        {
            HidePicture();
        }
    }

    public void ShowPicture(Sprite sprite)
    {
        pictureImage.sprite = sprite;

        panel.SetActive(true);
    }

    public void HidePicture()
    {
        panel.SetActive(false);
    }
}