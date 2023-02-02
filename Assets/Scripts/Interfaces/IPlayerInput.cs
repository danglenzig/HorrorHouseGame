using System.Collections.Generic;
using GameInput;

namespace Interfaces
{
    public interface IPlayerInput
    {
        IEnumerable<ButtonType> MappedButtons { get; }
        bool GetButtonDown(ButtonType buttonType);
        bool GetButton(ButtonType buttonType);
        bool GetButtonUp(ButtonType buttonType);
    }
}