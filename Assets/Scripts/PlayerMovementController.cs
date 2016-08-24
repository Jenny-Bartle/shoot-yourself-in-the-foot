using Assets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent (typeof(CharacterController))]
    class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        public CharacterController characterController;

        private float rightLeftSensitivity = 3;
        private float verticalSensitivity = 3;
        private float rightLeftRange = 1;
        private Vector3 lastForward;
        private float verticalRange = 60;

        private float jumpSpeed = 3;
        private float verticalRotation = 1.0f;
        private float verticalVelocity;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            lastForward = transform.forward;
            //Screen.locked
        }

        private void Update()
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -verticalRange, verticalRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            var rightLeftRotation = Input.GetAxis("Mouse X") * rightLeftSensitivity;
            var vecRL = new Vector3(0, rightLeftRotation, 0);
            var fwd = transform.TransformDirection(Vector3.forward + vecRL);
            //var foo = Mathf.Acos(Vector3.Dot(lastForward, fwd));
            //if (foo < rightLeftRange)
            //{
                transform.Rotate(vecRL);
            //}

            verticalVelocity += (Physics.gravity.y * Time.deltaTime);

            if (characterController.isGrounded)
            {
                fwd = new Vector3();

                if (Input.GetButtonDown("Jump"))
                {
                    // hopAnimator.SetBool("letsJump", true);
                    verticalVelocity = jumpSpeed;
                    lastForward = transform.forward;
                }
            }

            var velocity = new Vector3(fwd.x, verticalVelocity, fwd.z);
            characterController.Move(velocity * Time.deltaTime);
        }

        private void OnHopCameraJolt()
        {
            var now = System.DateTime.Now.Millisecond;
            while(System.DateTime.Now.Millisecond < now + 1000)
            {
                var rot = VectorUtil.CreateRandomUnitVector() * 3;
                Camera.main.transform.Rotate(rot);
            }
        }      
    }
}
