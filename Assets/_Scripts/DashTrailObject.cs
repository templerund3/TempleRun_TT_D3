﻿using UnityEngine;
using System.Collections;

public class DashTrailObject : MonoBehaviour
{
    public SpriteRenderer mRenderer;
    public Sprite[] sprPlayer;
    public Color mStartColor, mEndColor;

    private float mDisplayTime;
    private float mTimeDisplayed;
    private DashTrail mSpawner;


    // Update is called once per frame
    void Update()
    {
        mTimeDisplayed += Time.deltaTime;

        mRenderer.color = Color.Lerp(mStartColor, mEndColor, mTimeDisplayed / mDisplayTime);
        //transform.localScale = Vector3.Lerp(new Vector3(0.55f,0.55f,0.55f), new Vector3(0f, 0f, 0f), mTimeDisplayed / mDisplayTime);
        if (mTimeDisplayed >= mDisplayTime)
        {
            mSpawner.RemoveTrailObject(gameObject);
            Destroy(gameObject);
        }
    }

    public void Initiate(float displayTime, Sprite sprite,DashTrail trail)
    {
        mDisplayTime = displayTime;
        mRenderer.sprite = sprite;
        mTimeDisplayed = 0;
        mSpawner = trail;
    }
}
