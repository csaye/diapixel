using System.Collections.Generic;
using UnityEngine;

namespace Diapixel.Sketch3D
{
    [RequireComponent(typeof(MeshFilter))]
    public class CubeRenderer : MonoBehaviour
    {
        private Mesh mesh;
        private MeshCollider meshCollider;

        private List<Vector3Int> cubes = new List<Vector3Int>();

        private List<Vector3> vertices = new List<Vector3>();
        private List<int> triangles = new List<int>();
        private List<Color> colors = new List<Color>();

        private void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            mesh = meshFilter.mesh;
            meshCollider = GetComponent<MeshCollider>();
        }

        public void PlaceCube(Vector3Int position, Color color)
        {
            // If cube already exists at position, break cube
            if (cubes.Contains(position))
            {
                BreakCube(position);
            }

            cubes.Add(position);

            AddVertices(position);

            AddColors(color);

            UpdateMesh();
        }

        private void AddVertices(Vector3 position)
        {
            // Top
            AddFace(position, new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 0));
            // Bottom
            AddFace(position, new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1), new Vector3(0, 0, 1));
            // Left
            AddFace(position, new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0));
            // Right
            AddFace(position, new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1));
            // Front
            AddFace(position, new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0));
            // Back
            AddFace(position, new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1), new Vector3(0, 0, 1));

            AddTriangles();
        }

        private void AddFace(Vector3 position, Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, Vector3 vertex4)
        {
            vertices.Add(position + vertex1);
            vertices.Add(position + vertex2);
            vertices.Add(position + vertex3);
            vertices.Add(position + vertex4);
        }

        private void AddTriangles()
        {
            for (int cubeIndex = vertices.Count - 24; cubeIndex < vertices.Count; cubeIndex += 4)
            {
                triangles.Add(cubeIndex);
                triangles.Add(cubeIndex + 1);
                triangles.Add(cubeIndex + 2);

                triangles.Add(cubeIndex);
                triangles.Add(cubeIndex + 2);
                triangles.Add(cubeIndex + 3);
            }
        }

        private void AddColors(Color color)
        {
            for (int i = 0; i < 24; i++)
            {
                colors.Add(color);
            }
        }

        public void BreakCube(Vector3Int position)
        {
            // If no cube to break, return
            if (!cubes.Contains(position))
            {
                return;
            }

            RemoveVertices(position);

            UpdateMesh();

            cubes.Remove(position);
        }


        private void RemoveVertices(Vector3Int position)
        {
            int cubeIndex = cubes.IndexOf(position);

            int positionIndex = cubeIndex * 24;

            for (int i = 0; i < 24; i++)
            {
                vertices.RemoveAt(positionIndex);
                colors.RemoveAt(positionIndex);
            }

            RemoveTriangles();
        }

        private void RemoveTriangles()
        {
            for (int i = 0; i < 36; i++)
            {
                triangles.RemoveAt(triangles.Count - 1);
            }
        }

        private void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();

            mesh.colors = colors.ToArray();

            mesh.RecalculateNormals();

            meshCollider.sharedMesh = mesh;
        }
    }
}
