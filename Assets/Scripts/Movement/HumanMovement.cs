using System;
using UnityEngine;

namespace Movement
{
    public class HumanMovement : MovementBase
    {
        private void Update()
        {
            //Get Input
            MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            JumpCheck();
            RotatePlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }
    }
}
