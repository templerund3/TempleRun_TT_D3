using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour {

    public static Fade Instance;

    public enum FadeState
    {
        None, FadeInDone, FadeOutDone
    }

    public FadeState state;
    [HideInInspector] public Animator anim;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void StartFade()
    {
        anim.SetBool("In", true);
    }

    public void EndFade()
    {
        
        anim.SetBool("In", false);
        state = FadeState.None;
    }

    public void FadeInDone()
    {
        state = FadeState.FadeInDone;
    }

    public void FadeOutDone()
    {
        state = FadeState.FadeOutDone;
    }

}
