using UnityEngine;

namespace Diapixel.Sketch3D
{
    [RequireComponent(typeof(CharacterController))]
    public class UserMovement : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 0;
        [SerializeField] private float sprintSpeed = 0;
        [SerializeField] private float flySpeed = 0;
        [SerializeField] private float flySprintSpeed = 0;

        private CharacterController controller;

        private Vector3 flyVelocity;
        private Vector3 flySprintVelocity;

        private void Start()
        {
            controller = GetComponent<CharacterController>();

            flyVelocity = new Vector3(0, flySpeed, 0);
            flySprintVelocity = new Vector3(0, flySprintSpeed, 0);
        }        

        private void Update()
        {
            Move();
            Fly();
        }

        private void Move()
        {
            if (Sprinting())
            {
                controller.Move(MoveDirection() * sprintSpeed * Time.deltaTime);
            }
            else
            {
                controller.Move(MoveDirection() * moveSpeed * Time.deltaTime);
            }
        }

        private void Fly()
        {
            if (Input.GetButton("Jump"))
            {
                if (Sprinting())
                {
                    controller.Move(flySprintVelocity * Time.deltaTime);
                }
                else
                {
                    controller.Move(flyVelocity * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Sprinting())
                {
                    controller.Move(-flySprintVelocity * Time.deltaTime);
                }
                else
                {
                    controller.Move(-flyVelocity * Time.deltaTime);
                }
            }
        }

        private Vector3 MoveDirection()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            return transform.right * horizontal + transform.forward * vertical;
        }

        private bool Sprinting()
        {
            return Input.GetKey(KeyCode.LeftControl);
        }
    }
}
