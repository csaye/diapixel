using UnityEngine;
using UnityEngine.UI;

namespace Diapixel.Sketch3D.UI
{
    [RequireComponent(typeof(Slider))]
    public class OptionsSlider : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private SliderColor sliderColor = new SliderColor();

        [Header("References")]
        [SerializeField] private CubePlacer cubePlacer = null;

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
            Color cubeColor = cubePlacer.color;
            float value = slider.value;

            switch (sliderColor)
            {
                case SliderColor.Red:
                    cubePlacer.color = new Color(value, cubeColor.g, cubeColor.b);
                    break;
                case SliderColor.Green:
                    cubePlacer.color = new Color(cubeColor.r, value, cubeColor.b);
                    break;
                case SliderColor.Blue:
                    cubePlacer.color = new Color(cubeColor.r, cubeColor.g, value);
                    break;
            }
        }
    }
}
