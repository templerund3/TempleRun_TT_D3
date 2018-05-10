using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DashTrail : MonoBehaviour
{
    public SpriteRenderer mLeadingSprite;

    public int mTrailSegments;
    public float mTrailTime;
    public GameObject mTrailObject;

    private float mSpawnInterval;
    private float mSpawnTimer;
    private bool mbEnabled;

    private List<GameObject> mTrailObjects;

    // Use this for initialization
    void Start()
    {
        mSpawnInterval = mTrailTime / mTrailSegments;
        mTrailObjects = new List<GameObject>();
        mbEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mbEnabled)
        {
            mSpawnTimer += Time.deltaTime;

            if (mSpawnTimer >= mSpawnInterval)
            {
                GameObject trail = GameObject.Instantiate(mTrailObject);
                DashTrailObject trailObject = trail.GetComponent<DashTrailObject>();

                trailObject.Initiate(mTrailTime, mLeadingSprite.sprite, this);
                trail.transform.position = transform.position;
                trail.transform.localScale = mLeadingSprite.gameObject.transform.localScale;
                mTrailObjects.Add(trail);

                mSpawnTimer = 0;
            }
        }
    }

    public void RemoveTrailObject(GameObject obj)
    {
        mTrailObjects.Remove(obj);
    }

    public void SetEnabled(bool enabled)
    {
        mbEnabled = enabled;

        if (enabled)
        {
            mSpawnTimer = mSpawnInterval;
        }
    }

}