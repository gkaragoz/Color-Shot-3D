using UnityEngine;

public class Enums : MonoBehaviour {

    public enum GameState {
        MainMenu,
        GamePaused,
        NewGame,
        RestartGame,
        Gameplay,
        GameOver
    }

    public enum Colors {
        Red = 0,
        Green = 1,
        Blue = 2
    }

}
