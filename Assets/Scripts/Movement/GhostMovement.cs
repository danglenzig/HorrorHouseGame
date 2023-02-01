using UnityEngine;
using GD.MinMaxSlider;

namespace Movement
{
    public class GhostMovement : MovementBase
    {
        [MinMaxSlider(0, 10)] [SerializeField] private Vector2 floatRange;

        [SerializeField] private float floatSpeed;

        private float _desiredHeight;
        private Oscillator _osc;

        private void Start()
        {
            _osc = GetComponent<Oscillator>();
            _desiredHeight = floatRange.x;
        }

        private void Update()
        {
            _osc._localEquilibriumPosition.x = transform.position.x;
            _osc._localEquilibriumPosition.z = transform.position.z;

            //FLOATING:

            if (shouldJump)
            {
                _desiredHeight = floatRange.y;
                _osc._localEquilibriumPosition.y = Mathf.Lerp(_osc._localEquilibriumPosition.y, _desiredHeight,
                    Time.deltaTime * floatSpeed);
            }

            else
            {
                _desiredHeight = floatRange.x;
                _osc._localEquilibriumPosition.y = Mathf.Lerp(_osc._localEquilibriumPosition.y, _desiredHeight,
                    Time.deltaTime * floatSpeed);
            }

            RotatePlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }
    }
}