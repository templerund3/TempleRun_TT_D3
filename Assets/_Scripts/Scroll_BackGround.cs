using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_BackGround : MonoBehaviour {
    [SerializeField]
    private float ScrollSpeed = 0.5f;

    private float Offset;

    public bool isHome;

    void Update()
    {
        if (!isHome)
        {
            if (GameState.Instance.gamestate == STATE.PLAYING)
            {
                Offset += Time.deltaTime * ScrollSpeed;
                gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0.01f);
            }
        }
        else
        {
            Offset += Time.deltaTime * ScrollSpeed;
            gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0.01f);
        }

    }
}
