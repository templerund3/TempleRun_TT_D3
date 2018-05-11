using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_BackGround : MonoBehaviour {
    [SerializeField]
    private float ScrollSpeed = 0.5f;

    private float Offset;

    public bool isHome;

    public Material[] material_BG;

    void LateUpdate()
    {
        if (!isHome)
        {
            if (GameState.Instance.gamestate == STATE.PLAYING)
            {
                Offset += Time.fixedDeltaTime * ScrollSpeed;
                gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0f);
            }
        }
        else
        {
            Offset += Time.fixedDeltaTime * ScrollSpeed;
            gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0f);
        }
    }

    
}
