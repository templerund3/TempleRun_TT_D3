using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        anim.SetFloat("Index", (float)PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT));
    }
}
