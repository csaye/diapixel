using UnityEngine;
using UnityEngine.UI;

namespace Diapixel.Sketch2D.UI
{
    [RequireComponent(typeof(Slider))]
    public class OptionsSlider : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private SliderColor sliderColor = new SliderColor();

        [Header("References")]
        [SerializeField] private PixelPlacer pixelPlacer = null;

        private enum SliderColor
        {
            Red,
            Green,
            Blue
        }

        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void UpdateColor()
        {
            Color pixelColor = pixelPlacer.color;
            float value = slider.value;

            switch (sliderColor)
            {
                case SliderColor.Red:
                    pixelPlacer.color = new Color(value, pixelColor.g, pixelColor.b);
                    break;
                case SliderColor.Green:
                    pixelPlacer.color = new Color(pixelColor.r, value, pixelColor.b);
                    break;
                case SliderColor.Blue:
                    pixelPlacer.color = new Color(pixelColor.r, pixelColor.g, value);
                    break;
            }
        }
    }
}
