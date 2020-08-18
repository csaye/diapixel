using UnityEngine;
using UnityEngine.UI;

namespace Diapixel.Sketch2D.UI
{
    [RequireComponent(typeof(Image))]
    public class OptionsColor : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorType type = new ColorType();

        [Header("References")]
        [SerializeField] private PixelPlacer pixelPlacer = null;

        private enum ColorType
        {
            RedMin,
            RedMax,
            GreenMin,
            GreenMax,
            BlueMin,
            BlueMax,
            Total
        }

        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            Color color = new Color();
            Color pixelColor = pixelPlacer.color;
            
            switch (type)
            {
                case ColorType.RedMin:
                    color = new Color(0, pixelColor.g, pixelColor.b);
                    break;
                case ColorType.RedMax:
                    color = new Color(1, pixelColor.g, pixelColor.b);
                    break;
                case ColorType.GreenMin:
                    color = new Color(pixelColor.r, 0, pixelColor.b);
                    break;
                case ColorType.GreenMax:
                    color = new Color(pixelColor.r, 1, pixelColor.b);
                    break;
                case ColorType.BlueMin:
                    color = new Color(pixelColor.r, pixelColor.g, 0);
                    break;
                case ColorType.BlueMax:
                    color = new Color(pixelColor.r, pixelColor.g, 1);
                    break;
                case ColorType.Total:
                    color = pixelColor;
                    break;
            }

            image.color = color;
        }
    }
}
