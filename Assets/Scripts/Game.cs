using UnityEngine;

public static class Game
{
    public static TestInputs TestInputs { get; set; }

    public static void InitializeGame()
    {
        var gameObject = Object.Instantiate(Resources.Load<GameObject>(nameof(Game)), Vector3.zero, Quaternion.identity);
        var testInputs = gameObject.GetComponentInChildren<TestInputs>();
        testInputs.
    }
}