using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Diapixel
{
    public class Operation
    {
        public static bool IsMouseOverUI(bool ignoreBackground)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            if (ignoreBackground)
            {
                return results.Count > 1;
            }
            else
            {
                return results.Count > 0;
            }
        }
    }
}
