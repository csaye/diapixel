using UnityEngine;

namespace Diapixel.Sketch2D
{
    [RequireComponent(typeof(MeshFilter))]
    public class GridRenderer : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] [Range(0.01f, 0.1f)] private float lineThickness = 0.01f;

        [Header("References")]
        [SerializeField] private Camera mainCamera = null;

        private Mesh mesh;

        private List<Vector3> vertices = new List<Vector3>();
        private List<int> triangles = new List<int>();

        private void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            mesh = meshFilter.mesh;

            UpdateGrid();
        }

        // private void Update()
        // {
        //     UpdateGrid();
        // }

        private void UpdateGrid()
        {
            vertices.Clear();
            triangles.Clear();

            // Get min and max grid values from what is visible on screen
            Vector2 gridMin = mainCamera.ScreenToWorldPoint(Vector2.zero);
            Vector2 gridMax = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            int xMin = Mathf.CeilToInt(gridMin.x);
            int xMax = Mathf.FloorToInt(gridMax.x);
            int yMin = Mathf.CeilToInt(gridMin.y);
            int yMax = Mathf.FloorToInt(gridMax.y);

            // Create vertical lines
            for (int x = xMin; x <= xMax; x++)
            {
                Vector3 lowerLeft = new Vector3(x - lineThickness, gridMin.y, 0);
                Vector3 upperLeft = new Vector3(x - lineThickness, gridMax.y, 0);
                Vector3 upperRight = new Vector3(x + lineThickness, gridMax.y, 0);
                Vector3 lowerRight = new Vector3(x + lineThickness, gridMin.y, 0);

                vertices.Add(lowerLeft);
                vertices.Add(upperLeft);
                vertices.Add(upperRight);
                vertices.Add(lowerRight);
            }

            // Create horizontal lines
            for (int y = xMin; y <= yMax; y++)
            {
                Vector3 lowerLeft = new Vector3(gridMin.x, y - lineThickness, 0);
                Vector3 upperLeft = new Vector3(gridMin.x, y - lineThickness, 0);
                Vector3 upperRight = new Vector3(gridMin.x, y - lineThickness, 0);
                Vector3 lowerRight = new Vector3(gridMin.x, y - lineThickness, 0);

                vertices.Add(lowerLeft);
                vertices.Add(upperLeft);
                vertices.Add(upperRight);
                vertices.Add(lowerRight);
            }

            for (int i = 0; i < vertices.Count; i += 4)
            {
                triangles.Add(i);
                triangles.Add(i + 1);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 2);
                triangles.Add(i + 3);
            }

            UpdateMesh();
        }

        private void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
        }
    }
}
