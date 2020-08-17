using UnityEngine;

namespace Diapixel.Sketch2D
{
    public class CameraMovement : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float speed = 0;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction;

            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");

            transform.position = transform.position + (Vector3)(direction * speed * Time.deltaTime);
        }
    }
}
