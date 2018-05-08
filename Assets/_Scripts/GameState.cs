using UnityEngine;

public enum STATE
{
    NONE,
    PLAYING,
    GAMEOVER,
    GAMEWIN
}

public class GameState : MonoBehaviour
{


    public static GameState Instance = null;

    public STATE gamestate;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;

    }

    // Use this for initialization
    void Start()
    {
        gamestate = STATE.NONE;
        gamestate = STATE.PLAYING;
    }


}
