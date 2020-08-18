using UnityEngine;

namespace Diapixel.Sketch3D
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovement : MonoBehaviour
    {
        // [Header("Attributes")]
        // [SerializeField] private float moveSpeed = 0;
        // [SerializeField] private float flySpeed = 0;

        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            Move();
            Fly();
        }

        private void Move()
        {

        }

        private void Fly()
        {

        }
    }
}
