using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed = 0.5f;

    void Update ()
	{
        if (GameState.Instance.gamestate == STATE.PLAYING)
        {
            transform.Translate(Vector2.left * ScrollSpeed);
        }
	}
}



