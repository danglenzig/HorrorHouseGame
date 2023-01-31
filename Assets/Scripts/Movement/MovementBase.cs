using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        protected Vector3 MovementInput;
        protected Rigidbody Rb;

        [SerializeField] protected Transform feetTransform;
        [SerializeField] protected LayerMask floorMask;
        
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float jumpForce;

        protected bool CanJump;
        
        protected void Awake()
        {
            Rb = GetComponent<Rigidbody>();
        }
        
        protected void MovePlayer()
        {
            Vector3 moveDirection = MovementInput * moveSpeed;
            Rb.velocity = new Vector3(moveDirection.x, Rb.velocity.y, moveDirection.z);
        }

        protected void RotatePlayer()
        {
            if (MovementInput != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(MovementInput);
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
                Rb.MoveRotation(targetRotation);
            }
        }

        protected void JumpCheck()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Physics.CheckSphere(feetTransform.position, .25f, floorMask))
            {
                Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
