﻿using System.Collections.Generic;
using UnityEngine;

namespace Diapixel.Sketch2D
{
    [RequireComponent(typeof(MeshFilter))]
    public class PixelRenderer : MonoBehaviour
    {
        private Mesh mesh;

        [SerializeField] private List<Vector2Int> pixels = new List<Vector2Int>();

        [SerializeField] private List<Vector3> vertices = new List<Vector3>();
        [SerializeField] private List<int> triangles = new List<int>();

        private void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            mesh = meshFilter.mesh;
        }

        public void PlacePixel(Vector2Int position)
        {
            // If pixel already exists at position, break pixel
            if (pixels.Contains(position))
            {
                BreakPixel(position);
            }

            pixels.Add(position);

            AddVertices((Vector3Int)position);

            UpdateMesh();
        }

        private void AddVertices(Vector3 position)
        {
            vertices.Add(position);
            vertices.Add(position + Vector3.up);
            vertices.Add(position + Vector3.one);
            vertices.Add(position + Vector3.right);

            AddTriangles();
        }

        private void AddTriangles()
        {
            int pixelIndex = vertices.Count - 4;

            triangles.Add(pixelIndex);
            triangles.Add(pixelIndex + 1);
            triangles.Add(pixelIndex + 2);

            triangles.Add(pixelIndex);
            triangles.Add(pixelIndex + 2);
            triangles.Add(pixelIndex + 3);
        }

        public void BreakPixel(Vector2Int position)
        {
            // If no pixel to break, return
            if (!pixels.Contains(position))
            {
                return;
            }

            pixels.Remove(position);

            RemoveVertices(position);

            UpdateMesh();
        }


        private void RemoveVertices(Vector2Int position)
        {
            int pixelIndex = pixels.IndexOf(position);

            int positionIndex = pixelIndex * 4;

            for (int i = 0; i < 4; i++)
            {
                vertices.RemoveAt(positionIndex);
            }

            RemoveTriangles();
        }

        private void RemoveTriangles()
        {
            for (int i = 0; i < 6; i++)
            {
                triangles.RemoveAt(triangles.Count);
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
