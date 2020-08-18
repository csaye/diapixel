using UnityEngine;

namespace Diapixel.Sketch2D
{
    public class PixelPlacer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PixelRenderer pixelRenderer = null;
        [SerializeField] private Camera mainCamera = null;

        private void Update()
        {
            PlacePixel();
            BreakPixel();
        }

        private void PlacePixel()
        {
            if (Input.GetMouseButtonDown(1) && !MouseOverUI())
            {
                pixelRenderer.PlacePixel(MousePosition());
            }
        }

        private void BreakPixel()
        {
            if (Input.GetMouseButtonDown(0) && !MouseOverUI())
            {
                pixelRenderer.BreakPixel(MousePosition());
            }
        }
        
        private bool MouseOverUI()
        {

        }

        private Vector2Int MousePosition()
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        }

    }
}
