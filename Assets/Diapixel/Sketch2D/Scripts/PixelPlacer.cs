using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            if (Input.GetMouseButtonDown(1) && !IsMouseOverUI())
            {
                pixelRenderer.PlacePixel(MousePosition());
            }
        }

        private void BreakPixel()
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
            {
                pixelRenderer.BreakPixel(MousePosition());
            }
        }

        private bool IsMouseOverUI()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            // More than just background image
            return results.Count > 1;
        }

        private Vector2Int MousePosition()
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        }

    }
}
