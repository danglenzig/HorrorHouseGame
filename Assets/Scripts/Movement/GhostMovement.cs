using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Movement
{
    public class GhostMovement : MovementBase
    {

        [SerializeField] private float floatSpeed;
        
        private float _desiredHeight = 3f;
        private Oscillator _osc;

        private void Start()
        {
            _osc = GetComponent<Oscillator>();
        }

        private void Update()
        {
            //Get Input
            MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.Space))
            {
                _desiredHeight = 5f;
                _osc._localEquilibriumPosition.y = Mathf.Lerp(_osc._localEquilibriumPosition.y, _desiredHeight,
                    Time.deltaTime * floatSpeed);
            }

            else
            {
                _desiredHeight = 3f;
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
