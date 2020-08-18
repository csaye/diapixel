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

        public static Vector3Int FloorToInt(Vector3 v3)
        {
            int x = Mathf.FloorToInt(v3.x);
            int y = Mathf.FloorToInt(v3.y);
            int z = Mathf.FloorToInt(v3.z);

            return new Vector3Int(x, y, z);
        }
    }
}
