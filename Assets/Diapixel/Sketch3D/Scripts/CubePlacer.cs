using UnityEngine;

namespace Diapixel.Sketch3D
{
    public class CubePlacer : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float reach = 0;

        [Header("References")]
        [SerializeField] private CubeRenderer cubeRenderer = null;
        [SerializeField] private Transform userTransform = null;
        [SerializeField] private Transform cameraTransform = null;
        [SerializeField] private LayerMask cubeLayer = new LayerMask();

        public Color color {get; set;} = Color.black;

        private void Update()
        {
            PlaceCube();
            BreakCube();
        }

        private void PlaceCube()
        {
            if (Input.GetKeyDown("p"))
            {
                cubeRenderer.PlaceCube(UserPosition(), color);
            }

            if (Input.GetMouseButtonDown(1) && Cursor.lockState == CursorLockMode.Locked && !Operation.IsMouseOverUI(true))
            {
                RaycastHit hitInfo;

                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, reach, cubeLayer))
                {
                    Vector3 pointInTargetCube = hitInfo.point - (cameraTransform.forward * 0.01f);

                    Vector3Int position = Operation.FloorToInt(pointInTargetCube);
                    cubeRenderer.PlaceCube(position, color);
                }
            }
        }

        private Vector3Int UserPosition()
        {
            Vector3 userPosition = userTransform.position;

            int x = Mathf.FloorToInt(userPosition.x);
            int y = Mathf.FloorToInt(userPosition.y) - 1;
            int z = Mathf.FloorToInt(userPosition.z);

            return new Vector3Int(x, y, z);
        }

        private void BreakCube()
        {
            if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked && !Operation.IsMouseOverUI(true))
            {
                RaycastHit hitInfo;

                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, reach, cubeLayer))
                {
                    Vector3 pointInTargetCube = hitInfo.point + (cameraTransform.forward * 0.01f);

                    Vector3Int position = Operation.FloorToInt(pointInTargetCube);
                    cubeRenderer.BreakCube(position);
                }
            }
        }
    }
}
