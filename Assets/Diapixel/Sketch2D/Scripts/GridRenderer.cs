using System.Collections.Generic;
using UnityEngine;

namespace Diapixel.Sketch2D
{
    [RequireComponent(typeof(MeshFilter))]
    public class GridRenderer : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] [Range(0.01f, 0.1f)] private float lineThickness = 0.01f;

        [Header("References")]
        [SerializeField] private Transform cameraTransform = null;
        [SerializeField] private Camera mainCamera = null;

        private Mesh mesh;

        private List<Vector3> vertices = new List<Vector3>();
        private List<int> triangles = new List<int>();

        private Vector3 lastCameraPosition = Vector3.zero;

        private float offscreenExtent = 1;

        private bool active = true;

        private void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            mesh = meshFilter.mesh;
        }

        private void Update()
        {
            UpdateActive();

            // Update grid if camera has moved
            if (cameraTransform.position != lastCameraPosition)
            {
                UpdateGrid();
            }

            lastCameraPosition = cameraTransform.position;
        }

        private void UpdateActive()
        {
            if (Input.GetKeyDown("g"))
            {
                active = !active;
                UpdateGrid();
            }
        }

        public void UpdateGrid()
        {
            vertices.Clear();
            triangles.Clear();

            if (!active)
            {
                UpdateMesh();
                return;
            }

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
                Vector3 lowerLeft = new Vector3(x - lineThickness, gridMin.y - offscreenExtent, 0);
                Vector3 upperLeft = new Vector3(x - lineThickness, gridMax.y + offscreenExtent, 0);
                Vector3 upperRight = new Vector3(x + lineThickness, gridMax.y + offscreenExtent, 0);
                Vector3 lowerRight = new Vector3(x + lineThickness, gridMin.y - offscreenExtent, 0);

                vertices.Add(lowerLeft);
                vertices.Add(upperLeft);
                vertices.Add(upperRight);
                vertices.Add(lowerRight);
            }

            // Create horizontal lines
            for (int y = yMin; y <= yMax; y++)
            {
                Vector3 lowerLeft = new Vector3(gridMin.x - offscreenExtent, y - lineThickness, 0);
                Vector3 upperLeft = new Vector3(gridMin.x - offscreenExtent, y + lineThickness, 0);
                Vector3 upperRight = new Vector3(gridMax.x + offscreenExtent, y + lineThickness, 0);
                Vector3 lowerRight = new Vector3(gridMax.x + offscreenExtent, y - lineThickness, 0);

                vertices.Add(lowerLeft);
                vertices.Add(upperLeft);
                vertices.Add(upperRight);
                vertices.Add(lowerRight);
            }

            UpdateTriangles();

            UpdateMesh();
        }

        private void UpdateTriangles()
        {
            for (int i = 0; i < vertices.Count; i += 4)
            {
                triangles.Add(i);
                triangles.Add(i + 1);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 2);
                triangles.Add(i + 3);
            }
        }

        private void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
        }
    }
}
