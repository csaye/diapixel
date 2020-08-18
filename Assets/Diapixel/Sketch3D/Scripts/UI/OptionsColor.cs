using UnityEngine;
using UnityEngine.UI;

namespace Diapixel.Sketch3D.UI
{
    [RequireComponent(typeof(Image))]
    public class OptionsColor : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorType type = new ColorType();

        [Header("References")]
        [SerializeField] private CubePlacer cubePlacer = null;

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
            Color cubeColor = cubePlacer.color;
            
            switch (type)
            {
                case ColorType.RedMin:
                    color = new Color(0, cubeColor.g, cubeColor.b);
                    break;
                case ColorType.RedMax:
                    color = new Color(1, cubeColor.g, cubeColor.b);
                    break;
                case ColorType.GreenMin:
                    color = new Color(cubeColor.r, 0, cubeColor.b);
                    break;
                case ColorType.GreenMax:
                    color = new Color(cubeColor.r, 1, cubeColor.b);
                    break;
                case ColorType.BlueMin:
                    color = new Color(cubeColor.r, cubeColor.g, 0);
                    break;
                case ColorType.BlueMax:
                    color = new Color(cubeColor.r, cubeColor.g, 1);
                    break;
                case ColorType.Total:
                    color = cubeColor;
                    break;
            }

            image.color = color;
        }
    }
}
