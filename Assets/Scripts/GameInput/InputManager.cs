using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameInput
{
    public class InputManager : MonoBehaviour
    {
        private readonly IDictionary<ButtonType, ButtonState> buttonStates =
            new Dictionary<ButtonType, ButtonState>();

        private readonly IPlayerInput playerInput = new InputHandler();

        private bool IsInputLocked { get; set; }

        private void Update()
        {
            ReadInputs();
        }

        public bool GetButton(ButtonType button)
        {
            return playerInput.GetButton(button);
        }

        public bool GetButtonDown(ButtonType button)
        {
            return playerInput.GetButtonDown(button);
        }

        public bool GetButtonUp(ButtonType button)
        {
            return playerInput.GetButtonUp(button);
        }

        // CALL FROM GAME START PROCEDURE
        public void InitializeInput()
        {
            foreach (var mappedButton in playerInput.MappedButtons)
            {
                buttonStates.Add(mappedButton, ButtonState.None);
            }
        }

        public void SetInputLocked(bool setLocked)
        {
            if (IsInputLocked != setLocked)
            {
                IsInputLocked = setLocked;
            }

            ResetButtonStates();
        }

        private void ResetButtonStates()
        {
            foreach (var buttonState in buttonStates)
            {
                var button = buttonState.Key;
                buttonStates[button] = ButtonState.None;
            }
        }

        private void ReadInputs()
        {
            if (IsInputLocked)
            {
                return;
            }

            for (var i = 0; i < buttonStates.Count; i++)
            {
                var button = (ButtonType)i;
                if (playerInput.GetButtonDown(button))
                {
                    buttonStates[button] = ButtonState.Down;
                }
                else if (playerInput.GetButton(button))
                {
                    buttonStates[button] = ButtonState.Hold;
                }
                else if (playerInput.GetButtonUp(button))
                {
                    buttonStates[button] = ButtonState.Up;
                }
                else if (buttonStates.ContainsKey(button) && buttonStates[button] != ButtonState.None)
                {
                    buttonStates[button] = ButtonState.None;
                }
            }
        }
    }

    internal enum ButtonState
    {
        None,
        Down,
        Hold,
        Up
    }
}