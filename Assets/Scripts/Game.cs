using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Game
{
    public static CharacterHandler CharacterHandler { get; set; }
    public static PlayerInputManager PlayerInputManager { get; set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeGame()
    {
        var gameObject = Object.Instantiate(Resources.Load<GameObject>(nameof(Game)));
        CharacterHandler = gameObject.GetComponentInChildren<CharacterHandler>();
        PlayerInputManager = gameObject.GetComponentInChildren<PlayerInputManager>();
    }
}