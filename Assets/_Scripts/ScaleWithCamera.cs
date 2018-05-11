using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithCamera : MonoBehaviour {

    [System.Serializable]
    public enum TypeResize
    {
        All,
        OnlyWidth,
        OnlyHeight,
    }

    public TypeResize typeResize;

    void Awake()
    {
        switch (typeResize)
        {
            case TypeResize.All:
                ResizeWidthAndHeight();
                break;
            case TypeResize.OnlyWidth:
                ResizeOnlyWidth();
                break;
            case TypeResize.OnlyHeight:
                ResizeOnlyHeight();
                break;

        }

    }

   // public GameObject Test;
    void ResizeWidthAndHeight()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        //Debug.Log("Beffore bounds.size.x " + sr.sprite.bounds.size.x + " bounds.size.y " + sr.sprite.bounds.size.y);

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;

        //Debug.Log("Affter bounds.size.x " + sr.sprite.bounds.size.x + " bounds.size.y " + sr.sprite.bounds.size.y);
        //Test.transform.position = this.transform.position + new Vector3((sr.sprite.bounds.size.x * transform.localScale.x)/2, 0, 0);
    }

    void ResizeOnlyWidth()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;
    }

    void ResizeOnlyHeight()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float height = sr.sprite.bounds.size.y;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;
    }
}
