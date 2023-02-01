using UnityEngine;

namespace Movement
{
    public class HumanMovement : MovementBase
    {
        [SerializeField] protected Transform feetTransform;
        [SerializeField] protected LayerMask floorMask;

        [SerializeField] protected float jumpForce;

        private void Update()
        {
            JumpCheck();
            RotatePlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void JumpCheck()
        {
            if (shouldJump && Physics.CheckSphere(feetTransform.position, .25f, floorMask))
            {
                Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}