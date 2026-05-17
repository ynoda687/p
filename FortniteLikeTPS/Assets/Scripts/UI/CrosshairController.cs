using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Image crosshairImage;

    void Start()
    {
        if (crosshairImage != null)
        {
            // Canvas が Screen Space Overlay の前提
            crosshairImage.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            crosshairImage.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            crosshairImage.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}

