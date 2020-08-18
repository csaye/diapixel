using UnityEngine;

namespace Diapixel.Sketch3D
{
    public class CubePlacer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CubeRenderer cubeRenderer = null;
        [SerializeField] private Transform userTransform = null;

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
                cubeRenderer.PlaceCube(UserPosition(), Color.blue);
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

        }
    }
}
