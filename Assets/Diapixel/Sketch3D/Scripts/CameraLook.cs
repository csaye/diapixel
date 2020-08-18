using UnityEngine;

namespace Diapixel.Sketch3D
{
    public class CameraLook : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float mouseSensitivity = 0;

        [Header("References")]
        [SerializeField] private Transform userTransform = null;

        private float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            UpdateCursorState();
            Look();
        }

        private void UpdateCursorState()
        {
            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetMouseButtonDown(0) && !Operation.IsMouseOverUI(false))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void Look()
        {
            Vector2 mouseAxis = MouseAxis() * mouseSensitivity;

            LookHorizontal(mouseAxis.x);
            LookVertical(mouseAxis.y);
        }

        private void LookHorizontal(float mouseX)
        {
            userTransform.Rotate(Vector3.up * mouseX);
        }

        private void LookVertical(float mouseY)
        {
            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(yRotation, transform.localRotation.y, transform.localRotation.z);
        }

        private Vector2 MouseAxis()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            return new Vector2(mouseX, mouseY);
        }
    }
}
