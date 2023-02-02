using System.Collections;
using UnityEngine;

namespace Movement
{
    public class HumanMovement : MovementBase
    {
        [SerializeField] protected Transform feetTransform;
        [SerializeField] protected LayerMask floorMask;

        [SerializeField] protected float jumpForce;

        private bool _canJump = true;

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
            if (shouldJump && Physics.CheckSphere(feetTransform.position, .25f, floorMask) && _canJump)
            {
                Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                StartCoroutine(ResetJumpCooldown());
            }
        }

        private IEnumerator ResetJumpCooldown()
        {
            _canJump = false;
            yield return new WaitForSeconds(.2f);
            _canJump = true;
        }
    }
}